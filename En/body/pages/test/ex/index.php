<!doctype html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $_SERVER['DOCUMENT_ROOT']  . $Project . "/base/UIHelp.php";
$UIGroup = new UIGroup();
$blocks = $UIGroup->initBlocksForKeys();
$UIHelp = new UIHelp($blocks,$Project);
?>
<head>
	<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
	<?php
	$UIHelp->loadBase();
	$UIHelp->loadCSS();
	$UIHelp->loadJS();
	?>
	<script type="text/javascript" src="./ex.js"></script>
	<link rel="stylesheet" href="./ex.css">
	<script type="text/javascript">
		$(document).ready(function() {
			$.ajaxSetup ({
				cache: false
			});
		});
	</script>
</head>
<body onload='exMain()' class="grey lighten-5">
	<div id='pgContainer'>
		<div id='pgHeader'>
			<h4 class="left">說明</h4>
			<div class="clear"></div>
			<div class="card-panel">
				<span class="red-text text-darken-2">程式流程為：主畫面&nbsp;->&nbsp;選擇單字&nbsp;->&nbsp;背單字&nbsp;->&nbsp;測試單字&nbsp;->&nbsp;查詢結果</span>
			</div>
		</div>
		<div id='pgContent'>
			<div class="row">
				<h5>主畫面</h5>
				<h6>說明：輸入您的名字（英文代號）、年紀等資料，以及選擇連線中裝置後，即可開始測試</h6>
				<img src="img/main.png">
			</div>
			<hr>
			<div class="row">
				<h5>選擇單字頁面</h5>
				<h6>說明：請選擇您尚未看過的單字，選好選滿後就按下上方的按鈕，就可以開始背單字。</h6>
				<img src="img/choose.png">
				<h6>備註：按下<code>&nbsp;+&nbsp;</code>就可選擇，<code>&nbsp;-&nbsp;</code>會取消選取</h6>
			</div>
			<hr>
			<div class="row">
				<h5>背單字頁面</h5>
				<h6>說明：請在時間內背完選擇的單字，如果提早背完也可以提早考試，<code>要注意時間到的時候畫面會強制關閉，請集中注意力將單字背完。</code></h6>
				<img src="img/memory.png">
				<h6>備註：<code>聲音按鈕</code>可以聆聽發音。</h6>
				<h6>備註：<code>自行測試</code>會遮住單字，可以讓自己背背看，是否有背下。</h6>
				<h6>備註：<code>Google</code>可以查詢Google的單字資訊</h6>
			</div>
			<hr>
			<div class="row">
				<h5>測試頁面</h5>
				<h6>說明：測試您剛剛背的單字，寫完後先按<code>上傳，在按下上方的確認交卷。</code></h6>
				<img src="img/test.png">
				<h6>備註：<code>聲音按鈕</code>可以聆聽發音。</h6>
			</div>
			<hr>
			<div class="row">
				<h5>結果觀看</h5>
				<h6>說明：可觀看背單字時的資訊，也可查詢考試成績。</h6>
				<img src="img/result.png">
			</div>
		</div>
	</div>
</body>
</html>
