# DeekSeek-Unity

> **DeepSeek / 本地大模型接入 Unity Demo**

Unity 技术验证 Demo — DeepSeek / 本地大模型接入 Unity Demo

## 📋 基本信息

| 项目 | 内容 |
| --- | --- |
| 用途 | DeepSeek / 本地大模型接入 Unity Demo |
| Unity 版本 | `2021.3.15f1c1` |
| 主要场景数 | 1 |
| 主要脚本数 | 7 |
| 入库文件数 | 51 |
| 入库体积 | 0.2 MB |
| 本地路径 | `E:\Working\DemoFile\DeekSeek+Unity` |

## 🎯 功能要点

- Scripts/DeepSeekAPI.cs 云端 DeepSeek 接口调用
- Scripts/LocalDeepSeek.cs 本地模型（Ollama）推理
- Scripts/NPCInteraction.cs NPC 对话交互
- Scripts/PasswordAttribute.cs 密钥字段在 Inspector 中脱敏显示

## 🎬 主要场景

- `Scenes/SampleScene.unity`

## 📦 依赖说明

需自备 API Key（存于 Assets/AIConfig，仓库内为空占位）

> ⚠️ 本仓库部分第三方插件（付费插件 / Asset Store 资源）仅供个人学习与技术验证使用，不包含任何授权文件，商用请前往官方渠道购买正版授权。

## 📂 目录说明

| 目录 | 说明 |
| --- | --- |
| `Assets/` | 脚本、场景、预制体、贴图、插件 |
| `Packages/` | Unity Package Manager 依赖声明 |
| `ProjectSettings/` | Unity 工程配置 |

## ▶️ 运行方式

1. 使用 Unity `2021.3.15f1c1` 打开本工程`
2. 打开 `Assets/Scenes/` 下对应场景进入 Play 模式

---

*由众诚研发中心技术负责人整理上传 · 用途说明依据工程内场景/脚本内容自动生成*