<?php
include "UIHelp.php";
$Project = split("/base",$_SERVER[PHP_SELF])[0];
$block = $_POST["block"];
$UIGroup = new UIGroup();
$blocks = $UIGroup->initBlocksForKeys($block);
$UIHelp = new UIHelp($blocks,$Project);
$UIHelpItem = $UIHelp->getHelpItem($block);
$UIHelp->loadCSS();
$UIHelp->loadJS();
echo "loadHTML";
$UIHelp->loadHTML($block,null);
?>