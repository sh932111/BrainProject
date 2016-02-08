<!doctype html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<?php
	$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
	include $_SERVER['DOCUMENT_ROOT']  . $Project . "/base/UIHelp.php";
	$UIGroup = new UIGroup();
	$blocks = $UIGroup->initBlocksForKeys("chooseHeader","choose","footer");
	$UIHelp = new UIHelp($blocks,$Project);
?>
<head>
	<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
	<script type="text/javascript" src="./chooseWord.js"></script>
	<link rel="stylesheet" href="./chooseWord.css">
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
<body onload='chooseWordMain()' class="grey lighten-2">
	<div id='pgContainer'>
		<div id='pgHeader'>
			<?php $UIHelp->loadHTML("chooseHeader",null); ?>
		</div>
		<div id='pgContent'>
			<?php $UIHelp->loadHTML("choose",$_GET["orderID"]); ?>
		</div>
		<div id='pgFooter'>
			<?php $UIHelp->loadHTML("footer",null); ?>
		</div>
	</div>
</body>
</html>
