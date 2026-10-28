# Unity-Demos

> **Unity3D 技术验证 Demo 合集** — 90 个独立 Demo，每个子目录含独立用途说明与运行指引

本仓库汇总了我在 Unity3D 方向的技术验证项目，覆盖 **UI 交互**、**AI 大模型接入**、**特效插件集成**、**游戏原型**、**工业仿真**、**地图加载**、**框架源码精读** 等方向。所有 Demo 均由实际需求驱动，用于快速验证技术可行性。

## 📊 仓库概览

| 项目 | 数量 |
| --- | --- |
| Demo 总数 | 90 |
| 覆盖 Unity 版本 | 2017.1 ~ Unity 6000.0（含团结引擎 2022.3） |
| 收录文件 | 173455 |
| 入库体积 | 10.20 GiB（大文件走 Git LFS） |

## 📁 Demo 索引

### 核心功能 Demo（55）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Demo6.0_SRP_URP](Demo6.0_SRP_URP/) | Unity 6 URP 渲染管线 + DJI FPV 示例 | 6000.0.0f1c2 | 149.0 MB |
| [DemoLinux](DemoLinux/) | Linux 平台构建配置空工程 | 2018.4.0f1 | 0.0 MB |
| [Demo_2018.4.0_richang](Demo_2018.4.0_richang/) | Unity 2018.4 常规配置基线工程 | 2018.4.0f1 | 0.0 MB |
| [Demo_2021.2.7](Demo_2021.2.7/) | 综合技术验证工程（多插件集成） | 2021.2.7f1c1 | 1594.1 MB |
| [Demo_20230707](Demo_20230707/) | 综合技术验证工程 2（行为树 / AI / 曲线 / FPS） | 2021.3.15f1c1 | 1542.1 MB |
| [Demo_4.7Par](Demo_4.7Par/) | 粒子烟雾效果 Demo | 2019.4.7f1 | 5.6 MB |
| [Demo_6.0_HDRP](Demo_6.0_HDRP/) | Unity 6 HDRP 第一/第三人称控制器示例 | 6000.0.0f1c2 | 221.2 MB |
| [Demo_AndroidAndUnityInteraction](Demo_AndroidAndUnityInteraction/) | 安卓端与 Unity 端相互传递消息的小 Demo | 5.6.1f1 | 0.2 MB |
| [Demo_AssetBundle](Demo_AssetBundle/) | AssetBundle 打包与加载演示 | 5.6.1f1 | 75.5 MB |
| [Demo_Daily](Demo_Daily/) | 日常技术积累合集（按日期归档） | 2021.3.15f1c1 | 64.2 MB |
| [Demo_Daily_6.0](Demo_Daily_6.0/) | 数字人 / 虚拟人交互 Demo | 6000.0.0f1c2 | 143.4 MB |
| [Demo_Decoration](Demo_Decoration/) | 房地产 VR 场景 Demo | 2019.4.24f1c1 | 6632.4 MB |
| [Demo_DrawImg](Demo_DrawImg/) | Unity 读图与热力图绘制 Demo | 5.6.1f1 | 216.9 MB |
| [Demo_Exam](Demo_Exam/) | 在线考试系统 Demo | 2019.4.9f1 | 11.8 MB |
| [Demo_GetIpPos](Demo_GetIpPos/) | IP 定位与天气查询 Demo | 2018.1.0f2 | 1.3 MB |
| [Demo_GetTime](Demo_GetTime/) | 获取游戏时间并显示 Demo | 5.6.1f1 | 0.1 MB |
| [Demo_Hybridclr](Demo_Hybridclr/) | HybridCLR 热更新 DLL 加载 Demo | 2021.3.15f1c1 | 846.6 MB |
| [Demo_Input_Plugin_Drone](Demo_Input_Plugin_Drone/) | Rewired 输入插件与无人机操控 Demo | 2021.3.15f1c1 | 70.0 MB |
| [Demo_KGFMap](Demo_KGFMap/) | KGFMap 2D 地图系统 Demo | 2018.4.0f1 | 28.8 MB |
| [Demo_Login](Demo_Login/) | 登录流程与数据库存取 Demo | 5.6.1f1 | 1.4 MB |
| [Demo_LoopScrollRect](Demo_LoopScrollRect/) | 无限循环 ScrollRect 列表 Demo | 5.6.4f1 | 1.4 MB |
| [Demo_LuaStudy](Demo_LuaStudy/) | XLua 热更新与 Lua 交互学习 Demo | 2018.4.0f1 | 16.2 MB |
| [Demo_MVCTest](Demo_MVCTest/) | Unity MVC 模式与手绘墙体/Mesh 测试 | 5.6.1f1 | 3.3 MB |
| [Demo_NetworkRelayControl](Demo_NetworkRelayControl/) | PJLink 投影仪串口中控 Demo | 2018.4.12f1 | 2.2 MB |
| [Demo_Particle](Demo_Particle/) | FogVolume 体积雾与烟雾粒子 Demo | 2018.4.0f1 | 1.4 MB |
| [Demo_ParticleShow](Demo_ParticleShow/) | Shuriken Salvo 粒子齐射特效 Demo | 5.6.1f1 | 26.5 MB |
| [Demo_PlatformInterface](Demo_PlatformInterface/) | 网页/大屏平台双向对接 Demo | 2019.4.7f1 | 59.5 MB |
| [Demo_PlayerMove](Demo_PlayerMove/) | 角色移动与道路场景 Demo | 2018.4.0f1 | 7.9 MB |
| [Demo_Plugin2018.1.0f2](Demo_Plugin2018.1.0f2/) | Exploder 破坏插件 Demo | 2018.1.0f2 | 27.5 MB |
| [Demo_PointCloud](Demo_PointCloud/) | 点云加载、渲染与测量 Demo | 2019.4.24f1c1 | 259.5 MB |
| [Demo_Questions](Demo_Questions/) | 题库答题系统 v1 / v2 对照 Demo | 2019.4.7f1 | 3.8 MB |
| [Demo_Reflection](Demo_Reflection/) | C# 反射调用与外部 DLL 加载 Demo | 2019.2.8f1 | 0.1 MB |
| [Demo_SKFramework](Demo_SKFramework/) | SKFramework 框架源码与示例 | 2021.3.15f1c1 | 226.7 MB |
| [Demo_SendDataDLL](Demo_SendDataDLL/) | 通过 DLL 发送数据 Demo | 5.6.1f1 | 0.7 MB |
| [Demo_SerialPort](Demo_SerialPort/) | 串口通信与 Socket 客户端 Demo | 5.6.1f1 | 0.6 MB |
| [Demo_SerialPort_2019.3.8](Demo_SerialPort_2019.3.8/) | 串口通信 Demo（Unity 2019.3.8 版本） | 2019.3.8f1 | 0.1 MB |
| [Demo_Signed](Demo_Signed/) | 签名留言 Demo（手写签名 + 截图插件） | 2019.3.2f1 | 18.7 MB |
| [Demo_SplitModels](Demo_SplitModels/) | 模型切割 Demo（GameFramework + HybridCLR） | 2021.3.15f1c1 | 1119.6 MB |
| [Demo_SqliteTest](Demo_SqliteTest/) | SQLite 数据库存取与登录 Demo | 5.6.1f1 | 191.4 MB |
| [Demo_T2019.4](Demo_T2019.4/) | 六面顶压机工业仿真 Demo | 2019.4.9f1 | 158.7 MB |
| [Demo_TTS](Demo_TTS/) | 语音转文字（TTS）Demo | 2021.3.15f1c1 | 35.4 MB |
| [Demo_Test](Demo_Test/) | Unity 功能测试合集（多年度积累） | 5.6.1f1 | 504.1 MB |
| [Demo_TestPlugin](Demo_TestPlugin/) | Exploder 插件与碰撞体测试 Demo | 2018.1.0f2 | 27.5 MB |
| [Demo_TransformExtension](Demo_TransformExtension/) | Transform 扩展与自定义 Inspector Demo | 2021.3.15f1c1 | 0.3 MB |
| [Demo_UChart](Demo_UChart/) | UChart 数据图表 Demo（第三方插件） | 未标注 | 23.1 MB |
| [Demo_UDP](Demo_UDP/) | UDP 端口通信 Demo | 5.6.1f1 | 2.2 MB |
| [Demo_UITest](Demo_UITest/) | UI 测试占位工程 | 未标注 | 0.0 MB |
| [Demo_UnityFormations](Demo_UnityFormations/) | Texture Formation 队形渲染 Demo | 2021.2.7f1c1 | 7.0 MB |
| [Demo_WEBGLLoad2021](Demo_WEBGLLoad2021/) | WebGL 与外部数据交互 Demo（2021 版） | 2021.3.15f1 | 8.4 MB |
| [Demo_WEBGLLoadFile](Demo_WEBGLLoadFile/) | WebGL 与 PC 打开本地文件 Demo | 2019.4.9f1 | 8.3 MB |
| [Demo_WaterPlugins](Demo_WaterPlugins/) | 水面特效合集 Demo | 2021.3.15f1c1 | 4288.3 MB |
| [Demo_WebGLTemplate](Demo_WebGLTemplate/) | WebGL 自定义模板与编辑器工具 Demo | 2019.4.7f1 | 1.6 MB |
| [Demo_WebGLTest](Demo_WebGLTest/) | WebGL 综合测试（资源打包 / 通信 / 相机） | 2018.4.0f1 | 689.1 MB |
| [Demo_WebUpload](Demo_WebUpload/) | WebGL 网页数据上传与视频播放 Demo | 2019.4.24f1c1 | 7.8 MB |
| [Demo_tuanjie](Demo_tuanjie/) | 团结引擎（Tuanjie）空工程基线 | 2022.3.2t3 | 0.1 MB |

### AI 大模型接入（2）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [DeekSeek-Unity](DeekSeek-Unity/) | DeepSeek / 本地大模型接入 Unity Demo | 2021.3.15f1c1 | 0.2 MB |
| [DemoChat](DemoChat/) | ChatGPT 接入 Unity Demo（含编辑器窗口） | 2022.3.57f1c2 | 0.9 MB |

### 3D 展示与效果（3）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [3DImage](3DImage/) | DOTween Pro 补间动画示例合集 | 2022.3.57f1c2 | 11.8 MB |
| [SmokePark](SmokePark/) | 烟雾场景 Demo（高亮描边 / 动态天空） | 2022.3.57f1c2 | 136.1 MB |
| [U3DAvatar](U3DAvatar/) | 3D 数字人 Avatar 换装 Demo | 2018.4.0f1 | 94.2 MB |

### 游戏原型（2）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Game2048](Game2048/) | 2048 小游戏 Demo | 2022.3.57f1c2 | 0.2 MB |
| [Game_Parkour](Game_Parkour/) | Unity 开发跑酷游戏 Demo | 5.6.1f1 | 8.2 MB |

### 插件集成 Demo（4）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Plugin_DoozyUI](Plugin_DoozyUI/) | DoozyUI 插件示例 Demo | 2018.1.0f2 | 69.9 MB |
| [Plugin_MultipleGraphAndChartUIPack](Plugin_MultipleGraphAndChartUIPack/) | 多图表数据可视化 UI 包 Demo | 2019.4.7f1 | 72.9 MB |
| [Plugin_XCharts](Plugin_XCharts/) | XCharts 图表插件 Demo | 2018.3.7f1 | 51.1 MB |
| [XCharts_Demo](XCharts_Demo/) | XCharts 官方示例 Demo | 2019.4.9f1 | 8.5 MB |

### 框架与平台对接（1）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Frame_TestVRFrame](Frame_TestVRFrame/) | VR 帧同步与平台数据上传测试工程 | 2019.3.8f1 | 229.5 MB |

### 工业仿真（3）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [FactoryScene_URP](FactoryScene_URP/) | URP 工厂场景 Demo（水体 / 动态天空 / 动态树） | 2021.3.2f1c1 | 1745.6 MB |
| [PackagerDemo](PackagerDemo/) | 航空发动机结构拆解演示 Demo | 2021.3.15f1c1 | 121.0 MB |
| [XD_Drone](XD_Drone/) | 无人机巡检仿真 Demo（地形 / FPV） | 2021.3.15f1c1 | 1365.9 MB |

### 地图与地理（1）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [MapLoad](MapLoad/) | 多地图源加载 Demo（百度 / 高德 / Cesium） | 2021.3.15f1c1 | 0.3 MB |

### AR 增强（1）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [EasyAR](EasyAR/) | EasyAR AR 效果 Demo | 6000.0.0f1c2 | 0.4 MB |

### 题库与考试（2）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Answer](Answer/) | 答题交互控制最小 Demo | 2022.3.57f1c2 | 9.6 MB |
| [AnswerModule](AnswerModule/) | 考试题库模块示例（Excel 导入 + IOC） | 2019.4.7f1 | 3.0 MB |

### 开源项目精读（6）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [GF_GameDemo](GF_GameDemo/) | GameFramework StarForce 官方示例 Demo | 未标注 | 483.0 MB |
| [QFramework_Study](QFramework_Study/) | QFramework 框架学习 Demo（含官方全部示例） | 6000.0.23f1c1 | 13.0 MB |
| [RWS-master](RWS-master/) | RWS FPV 竞速翼模拟器 Demo（含 Photon 联机） | 2021.3.15f1c1 | 767.4 MB |
| [SKFramework_Study](SKFramework_Study/) | SKFramework 框架学习与资源打包 Demo | 6000.0.23f1c1 | 74.7 MB |
| [UnityDroneSim-master](UnityDroneSim-master/) | Unity ML-Agents 无人机仿真 Demo | 2018.2.5f1 | 65.5 MB |
| [cesium-unity-samples-1.11.1](cesium-unity-samples-1.11.1/) | Cesium for Unity 官方示例集 | 2021.3.15f1c1 | 89.4 MB |

### 天气与环境（3）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [Weather](Weather/) | 天气查询 Demo | 2022.3.57f1c2 | 1.2 MB |
| [WeatherDemoAssets](WeatherDemoAssets/) | 天气演示素材资源包 | 未标注 | 0.9 MB |
| [WeatherPlugin_UniStorm](WeatherPlugin_UniStorm/) | UniStorm 天气系统插件 Demo | 2021.3.15f1c1 | 218.8 MB |

### 专项验证（2）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [PSE](PSE/) | 地图选点与加载 Demo（PSE） | 2017.1.0f3 | 9.6 MB |
| [Route](Route/) | 路线规划占位工程 | 2021.3.15f1c1 | 0.1 MB |

### 其他 Demo（4）

| Demo | 用途说明 | Unity 版本 | 体积 |
| --- | --- | --- | --- |
| [ChangeClothe](ChangeClothe/) | 角色换装系统 Demo | 2022.3.57f1c2 | 94.3 MB |
| [FPS](FPS/) | FPS 战斗 Demo（状态机 / 枪械 / 血量） | 2022.3.57f1c2 | 135.2 MB |
| [FPSMicrogame](FPSMicrogame/) | FPS Microgame 官方示例 Demo | 2019.4.9f1 | 161.3 MB |
| [ParkourGame](ParkourGame/) | 跑酷游戏 Demo（Unity 2021.3 版本） | 2021.3.15f1c1 | 8.3 MB |

## 🚀 使用说明

每个 Demo 都是**独立 Unity 工程**，使用方式一致：

1. 克隆本仓库（或仅下载所需子目录）
2. 用对应版本的 Unity Hub 打开该子目录
3. 打开 `Assets/Scenes/` 下的场景，进入 Play 模式

> ⚠️ 若克隆时未拉取 LFS 文件（出现指针文件），执行 `git lfs pull` 补全大体积资源。

## 📄 各 Demo 说明文件

每个子目录均包含独立的 `README.md`，说明：

- 该 Demo 解决什么问题、验证什么技术点
- 主要场景与核心脚本位置
- 依赖的第三方插件与运行前置条件

## ⚖️ 授权与声明

1. **第三方插件**：本仓库中部分 Demo 引用了 Unity Asset Store 等渠道的商业插件（DOTween Pro、Water FX Collection、DoozyUI、Rewired、XCharts 等），**仅包含其运行所需的插件文件，不含任何授权凭据**。相关版权归属原作者，商用请前往官方渠道购买正版授权。
2. **敏感信息**：所有真实凭据（API Key、Token、AppID、内网地址、第三方平台密钥）均已替换为占位符（如 `YOUR_TOKEN`、`YOUR_APPID`），使用时请自行填入。原始文件未提交至版本库。
3. **大体积资产**：受 GitHub 单文件 100MB 限制与 LFS 配额约束，部分超大模型/贴图/视频资产（单文件 > 2MB 的媒体资源）未纳入版本库，各 Demo 的 README 中已标注主要依赖。

## 📮 联系我

- GitHub：[@764424567](https://github.com/764424567)
- CSDN：[blog.csdn.net/q764424567](https://blog.csdn.net/q764424567)

---

*由众诚研发中心技术负责人整理 · 2026-10-28*