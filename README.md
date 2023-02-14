# タイトル
## 準備(セットアップ)
### Unityのダウンロード
1. [UnityHub](<https://unity3d.com/jp/get-unity/download>)をインストール。
<img width="550" alt="スクリーンショット 2021-12-02 113859" src="https://user-images.githubusercontent.com/72001573/144347599-1c0f6b01-6f05-4900-91ee-c7bcec353a68.png">

2. [こちら](https://unity3d.com/unity/qa/lts-releases)のサイトからver 2021.3.13f1を探しUnityHub経由でインストールを行う。
![image](https://user-images.githubusercontent.com/72001573/218735041-51b14499-7dc8-480f-a400-a4cefe9db62f.png)

### ビルド
1. 本レポジトリからcodeに進み、Download Zipをクリックし、ゲームデータをダウンロードする。
![image](https://user-images.githubusercontent.com/72001573/218735547-6a4a9faa-f34f-4a87-8643-f94314e10eae.png)

2. ダウンロードしたzipファイルを解凍する。
3. unityを開く。
    ![3](https://user-images.githubusercontent.com/89173987/144359951-792736f4-fdf6-40fa-a351-c95f471f750b.jpg)
4. リストに追加で、2.で解凍したファイルから、gameprogを追加する。
5. プロジェクトに追加されたのを確認して開く。
6. FileからBuild Settingを開く
![image](https://user-images.githubusercontent.com/72001573/218736695-36f5e2cc-3a3b-4d40-82d6-f5ee3ac30367.png)
7. Build Settingsが開くので、Platformを「Windows,Mac,Linux」を選んだのを確認下の後に、Build And Runを選択
![image](https://user-images.githubusercontent.com/72001573/218737080-82a0c402-bb86-4efa-83ce-52c7414f055c.png)
8. 保存先を選び、ビルドを開始する
9. 保存先にあるResearch.exeをクリックするとゲームが開始される
![image](https://user-images.githubusercontent.com/72001573/218737830-c0eb8ac1-2faa-4f54-ba70-92973fbb472f.png)

## 遊び方
### タイトル画面
![image](https://user-images.githubusercontent.com/72001573/218738504-8e21ddc9-51e2-4db4-bcce-61486dfeb7ee.png)
- [GAME START]→ゲームが実行される
- [OPTION]→敵の数と、的プログラムの可視数について設定ができる
- [EXIT]→ ゲーム終了
### オプション画面
![image](https://user-images.githubusercontent.com/72001573/218738640-4a8cd239-237b-4e32-bf25-9906549ef09b.png)
- 敵の数 →ゲーム開始時の敵の数を選択できる
- 暗黙モード → 的プログラムの可視状況を選択できる
設定し、最後に保存を押すとオプション状況を保存できる。
### ゲーム画面
![image](https://user-images.githubusercontent.com/72001573/218739159-8219caf9-30a8-446e-b1d8-0c78025c0355.png)

本ゲームは、敵のプログラムを読み解きながら、自身のプログラムを組み立て、優位にゲームを進めるものである。プログラミングフェイズ→プログラム実行フェイズという流れを敵もしくはプレイヤーが倒されるまで繰り返される。
- プログラミングフェイズ→コマンドを入力し、プログラムを組み立てる時間
- プログラム実行フェイズ→敵と自身のプログラムを１つずつ実行していく時間

![image](https://user-images.githubusercontent.com/72001573/218740195-75afe0d1-9f6d-4bca-a30d-02fc96fa6d37.png)\
- コマンド１つ１つにはコストの概念があり、プログラム中に含めるコストに制限がある。本ゲームでは１つのプログラムに25コストまでしかコマンドを入れることはできない
- コマンド１つ１つに説明機能があるので、コマンドの説明やコスト、攻撃力の確認が可能である。
- コマンドを組み立て、最後にRunボタンを押すと、プログラム実行フェイズに移行する。

