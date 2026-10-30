# AnswerModule

> **考试题库模块示例（Excel 导入 + IOC）**

Unity 技术验证 Demo — 考试题库模块示例（Excel 导入 + IOC）

## 📋 基本信息

| 项目 | 内容 |
| --- | --- |
| 用途 | 考试题库模块示例（Excel 导入 + IOC） |
| Unity 版本 | `2019.4.7f1` |
| 主要场景数 | 1 |
| 主要脚本数 | 12 |
| 入库文件数 | 103 |
| 入库体积 | 3.0 MB |
| 本地路径 | `E:\Working\DemoFile\AnswerModule` |

## 🎯 功能要点

- Exam/Scripts/DataPool/ExamManager.cs 题库数据池
- Exam/Scripts/Editor/ReadExcel.cs Excel 题库导入
- Exam/Scripts/IOC/IOC.cs 轻量 IOC 容器

## 🎬 主要场景

- `Exam/Scenes/QuestionTest.unity`

## 📦 依赖说明

Newtonsoft JSON；Excel 题库文件位于 StreamingAssets

> ⚠️ 本仓库部分第三方插件（付费插件 / Asset Store 资源）仅供个人学习与技术验证使用，不包含任何授权文件，商用请前往官方渠道购买正版授权。

## 📂 目录说明

| 目录 | 说明 |
| --- | --- |
| `Assets/` | 脚本、场景、预制体、贴图、插件 |
| `Packages/` | Unity Package Manager 依赖声明 |
| `ProjectSettings/` | Unity 工程配置 |

## ▶️ 运行方式

1. 使用 Unity `2019.4.7f1` 打开本工程`
2. 打开 `Assets/Scenes/` 下对应场景进入 Play 模式

---

*由众诚研发中心技术负责人整理上传 · 用途说明依据工程内场景/脚本内容自动生成*