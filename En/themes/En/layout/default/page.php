<?php
$head = '/plug/head';
$foot = '/plug/foot';
$UIHelp->initBlocks($head,$foot);
?>
<!doctype html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
	<title><?php echo $ctx["title"]; ?></title>
	<meta name="description" content="<?php echo $ctx["description"]; ?>" />
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<!-- <link rel="shortcut icon" href="../../wcoim/backstage/favicon.ico"> -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
	<?php $UIHelp->includeCss(); ?>
	<?php $UIHelp->includeJs(); ?>
	<style type="text/css">
		<?php $UIHelp->layoutCSS();?>
		<?php $UIHelp->css(); ?>
	</style>
	<script type="text/javascript">
		<?php $UIHelp->js(); ?>
		$(document).ready(function() {
			$.ajaxSetup ({
				cache: false
			});
			__.initPage();
		});
	</script>
</head>
<body>
	<div id='pgContainer'>
		<div id='pgHeader'>
			<?php $UIHelp->block($head,true); ?>
		</div>
		<div id='pgContent'>
			<?php $UIHelp->mainBlock(true); ?>
		</div>
		<div id='pgFooter'>
			<?php $UIHelp->block($foot,true); ?>
		</div>
	</div>
</body>
</html>
