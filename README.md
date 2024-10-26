# MFD Frame Image Disp Tool
====


###使用方法

コマンドライン引数で指定

TopMostDispImage.exe モニタ番号 X座標 Y座標 幅 高さ 透過指定 画像ファイル名

モニタ番号 : モニタの番号（1～）

X座標 : 画像を表示するモニタのX座標(ピクセル)

Y座標 : 画像を表示するモニタのY座標(ピクセル)

幅 : 画像を表示する幅(ピクセル)

高さ : 画像を表示する高さ(ピクセル)

透過指定 : 0=透過しない,1=黒色を透過させる

画像ファイル名 : imageフォルダ内の画像ファイル名


###終了方法

タスクバーのアプリアイコンを右クリックで「ウィンドウを閉じる」または「すべてのウィンドウを閉じる」で終了させてください



###DCS MonitorSetupの推奨MFDサイズ
	x      = (768 - 745) / 2.0;
	y      = 1024 - 745 - 19;
	width  = 745
	height = 745


###AH64DのDCS MonitorSetupの推奨MFDサイズ
	x      = (768 - 634) / 2.0;
	y      = 1024 - 634 - 65;
	width  = 634
	height = 634



## 開発環境
 Microsoft Visual Studio Community 2022

## 必要ランタイム
 .NET 8.0

## Licence
* MIT  
    * see LICENSE

## Author

[itom](https://github.com/itom0717)
