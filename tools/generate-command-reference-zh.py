import argparse
import json
import subprocess
from collections import defaultdict
from pathlib import Path


MODULE_LABELS = {
    "": "核心与通用",
    "Animation": "动画",
    "Assets": "资源",
    "GameObject": "游戏对象",
    "Profiler": "性能分析",
    "Scene": "场景",
    "NuGet": "NuGet",
    "Remote": "远程",
    "Recorder": "录制",
    "Search": "搜索",
}


def append_field_table(lines, fields):
    if not fields:
        lines.append("无")
        lines.append("")
        return

    lines.append("| 字段 | 类型 | 默认值 |")
    lines.append("|---|---|---|")
    for field in fields:
        default_value = (field.get("defaultValue") or "").replace("\r", " ").replace("\n", " ")
        lines.append(f"| `{field['name']}` | `{field['type']}` | `{default_value}` |")
    lines.append("")


def resolve_module_label(module_name: str) -> str:
    return MODULE_LABELS.get(module_name, module_name or "核心与通用")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--project-path", required=True)
    parser.add_argument("--cli-path", required=True)
    parser.add_argument("--output-path", required=True)
    args = parser.parse_args()

    cli_path = Path(args.cli_path)
    if not cli_path.exists():
        raise FileNotFoundError(f"CLI not found: {cli_path}")

    env = dict(**subprocess.os.environ)
    env["UNICLI_PROJECT"] = args.project_path
    result = subprocess.run(
        [str(cli_path), "commands", "--json"],
        check=True,
        capture_output=True,
        text=True,
        encoding="utf-8",
        env=env,
    )

    payload = json.loads(result.stdout)
    if not payload.get("success"):
        raise RuntimeError(f"Failed to fetch command list: {payload.get('message')}")

    commands = payload["data"]
    groups = defaultdict(list)
    for cmd in sorted(commands, key=lambda item: ((item.get("module") or ""), item["name"])):
        groups[cmd.get("module") or ""].append(cmd)

    ordered_modules = sorted(groups.keys(), key=lambda name: "0-Core" if name == "" else name)

    lines = []
    lines.append("# UniCli 中文命令参考")
    lines.append("")
    lines.append("> 由 `unicli commands --json` 自动生成。")
    lines.append("> 文档结构与使用说明为中文，命令名、字段名和类型名保持原样，便于与 CLI 输出一一对应。")
    lines.append("")
    lines.append("## 概览")
    lines.append("")
    lines.append(f"- 命令总数：**{len(commands)}**")
    lines.append(f"- Unity 项目：`{args.project_path}`")
    lines.append(f"- CLI 路径：`{args.cli_path}`")
    lines.append("")
    lines.append("常用调用格式：")
    lines.append("")
    lines.append("```powershell")
    lines.append(f'$env:UNICLI_PROJECT = "{args.project_path}"')
    lines.append(f'& "{args.cli_path}" exec Compile --json')
    lines.append(f'& "{args.cli_path}" exec GameObject.Find --namePattern "Camera" --json')
    lines.append("```")
    lines.append("")
    lines.append("## 模块目录")
    lines.append("")

    for module_name in ordered_modules:
        label = resolve_module_label(module_name)
        lines.append(f"- **{label}**：{len(groups[module_name])} 条")

    lines.append("")

    for module_name in ordered_modules:
        label = resolve_module_label(module_name)
        lines.append(f"## {label}")
        lines.append("")

        for cmd in groups[module_name]:
            lines.append(f"### {cmd['name']}")
            lines.append("")
            lines.append(f"- 原始说明：{cmd.get('description') or ''}")
            lines.append(f"- 模块：{module_name or 'Core/Uncategorized'}")
            lines.append(f"- 内置命令：{cmd.get('builtIn')}")
            lines.append("")
            lines.append("**请求字段**")
            lines.append("")
            append_field_table(lines, cmd.get("requestFields") or [])
            lines.append("**响应字段**")
            lines.append("")
            append_field_table(lines, cmd.get("responseFields") or [])

            nested = list(cmd.get("requestTypeDetails") or []) + list(cmd.get("responseTypeDetails") or [])
            if nested:
                lines.append("**嵌套类型详情**")
                lines.append("")
                for detail in nested:
                    lines.append(f"- 类型：`{detail['typeName']}`")
                    lines.append(f"- TypeId：`{detail['typeId']}`")
                    lines.append("")
                    lines.append("| 字段 | 类型 | 默认值 |")
                    lines.append("|---|---|---|")
                    for field in detail.get("fields") or []:
                        default_value = (field.get("defaultValue") or "").replace("\r", " ").replace("\n", " ")
                        lines.append(f"| `{field['name']}` | `{field['type']}` | `{default_value}` |")
                    lines.append("")

            lines.append("---")
            lines.append("")

    output_path = Path(args.output_path)
    output_path.write_text("\n".join(lines), encoding="utf-8")
    print(f"Generated {output_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
