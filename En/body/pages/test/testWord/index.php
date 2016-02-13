<!doctype html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<?php
	$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
	include $_SERVER['DOCUMENT_ROOT']  . $Project . "/base/UIHelp.php";
	$UIGroup = new UIGroup();
	$blocks = $UIGroup->initBlocksForKeys("testHeader","testPage","footer");
	$UIHelp = new UIHelp($blocks,$Project);
?>
<head>
	<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
	<script type="text/javascript" src="./testWord.js"></script>
	<link rel="stylesheet" href="./testWord.css">
	<script type="text/javascript" src="/En/resource/lib/mespeak/mespeak.js"></script>
	<?php
		$UIHelp->loadBase();
		$UIHelp->loadCSS();
		$UIHelp->loadJS();
	?>
	<script type="text/javascript">
      	$(document).ready(function() {
          	$.ajaxSetup ({
            	cache: false
          	});
      	});
    </script>
</head>
<body onload='testWordMain()' class="amber lighten-5">
	<div id='pgContainer'>
		<div id='pgHeader'>
			<?php $UIHelp->loadHTML("testHeader",null); ?>
		</div>
		<div id='pgContent'>
			<?php
				$UIHelp->loadHTML("testPage",$_GET["orderID"]); 
			?>
		</div>
		<div id='pgFooter'>
			<?php $UIHelp->loadHTML("footer",null); ?>
		</div>
	</div>
</body>
</html>
