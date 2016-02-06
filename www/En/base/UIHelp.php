<?php
include "HttpWorker.php";
class UIGroup {
	public function initBlocksForKeys() {
		$res = array();
    	foreach (func_get_args() as $key) {
	        array_push($res,$key);
	    }
	    return $res;
	}
}
class UIHelp {
	private $helpItemskeys = null;
	private $UIHelpItems = null;
	private $sitesJson = null;
	function __construct($blocks,$project) {
		$GLOBALS["Project"] = $project;
		$jsonPath = $_SERVER['DOCUMENT_ROOT'] . $GLOBALS["Project"] . "/config/block.json";
		$sites_file = file_get_contents($jsonPath);
		$this->sitesJson = json_decode($sites_file, true);
		$this->UIHelpItems = array();
		$this->helpItemskeys = array();
		for ($i=0; $i < count($blocks); $i++) { 
			$block = $blocks[$i];
			$path = $this->sitesJson[$block]["path"] . "/" . $block;
			$bkID = $this->getID($block);
			$UIHelpItem = new UIHelpItem($path,$bkID);
			$this->UIHelpItems[$block] = $UIHelpItem;
			array_push($this->helpItemskeys,$block);
		}
	}
	public function loadHTML($key,$GET_value) {
		$UIHelpItem = $this->UIHelpItems[$key];
		$html = $UIHelpItem->getHTMLPath();
		$modules = $GLOBALS["Project"] . "/body/modules" . $this->sitesJson[$key]["path"] . "/" . $key . ".php";
		$response = "null";
		/*Call js init function*/
		if (is_file($_SERVER['DOCUMENT_ROOT'] . $modules)) {
			include $_SERVER['DOCUMENT_ROOT'] . $modules;
			$classname = $key . "Modules";
			$response = call_user_func(__NAMESPACE__ . "\\" . $classname .'::run',$GET_value);
		}
		else {
 			$service = $this->sitesJson[$key]["service"];
			if (!empty($service)) {
				$url = $service["url"];
				if (!empty($url)) {
					if (strlen($url) != 0) {
						$post = $service["post"];
						$httpWorker = new HttpWorker($url);
						$response = $httpWorker->post($post);
					}
				}
			}
		}
		$bkID = $UIHelpItem->getBkID();
		echo "<div id=" . $bkID  . ">";
		include $_SERVER['DOCUMENT_ROOT'] . $html;
		echo "</div>";
		echo '<script> new ctrlManager("' . $bkID . '","' . $GET_value . '",' . $response . '); </script>';
		echo '<script> ' . $key . 'BlockMain("' . $bkID . '"); </script>';
	}
	public function loadJS() {
		for ($i=0; $i < count($this->helpItemskeys); $i++) { 
			$key = $this->helpItemskeys[$i];
			$UIHelpItem = $this->UIHelpItems[$key];
			$js = $UIHelpItem->getJSPath();
			if (is_file($_SERVER['DOCUMENT_ROOT'] . $js)) {
				$bkID = "js" . $UIHelpItem->getBkID();
				echo '<script id="' . $bkID . '" type="text/javascript" src="' . $js . '"></script>';
			}
		}
	}
	public function loadCSS() {
		for ($i=0; $i < count($this->helpItemskeys); $i++) { 
			$key = $this->helpItemskeys[$i];
			$UIHelpItem = $this->UIHelpItems[$key];
			$css = $UIHelpItem->getCSSPath();
			$bkID = "css" . $UIHelpItem->getBkID();
			if (is_file($_SERVER['DOCUMENT_ROOT'] . $css)) {
				echo '<link id="' . $bkID . '" rel="stylesheet" href="' . $css . '">';
			}
		}
	}
	public function loadBase() {
		$jsonPath = $_SERVER['DOCUMENT_ROOT'] . $GLOBALS["Project"] . "/config/base.json";
		$sites_file = file_get_contents($jsonPath);
		$baseJson = json_decode($sites_file, true);
		$httpCssLibs = $baseJson["httpCss"];
		for ($i=0; $i < count($httpCssLibs); $i++) {
			$path = $httpCssLibs[$i];
			echo '<link rel="stylesheet" href="' . $path . '">';
		}
		$cssLibs = $baseJson["css"];
		for ($i=0; $i < count($cssLibs); $i++) {
			$path = $cssLibs[$i];
			$this->loadCSSLib($path);
		}
		$httpJsLibs = $baseJson["httpJs"];
		for ($i=0; $i < count($httpJsLibs); $i++) {
			$path = $httpJsLibs[$i];
			echo '<script type="text/javascript" src="' . $path . '"></script>';
		}
		$jsLibs = $baseJson["js"];
		for ($i=0; $i < count($jsLibs); $i++) {
			$path = $jsLibs[$i];
			$this->loadJSLib($path);
		}
	}
	public function loadJSLib($jslib) {
		$path = $GLOBALS["Project"] . $jslib;
		if (is_file($_SERVER['DOCUMENT_ROOT'] . $path)) {
			echo '<script type="text/javascript" src="' . $path . '"></script>';
		}
	}
	public function loadCSSLib($csslib) {
		$path = $GLOBALS["Project"] . $csslib;
		if (is_file($_SERVER['DOCUMENT_ROOT'] . $path)) {
			echo '<link rel="stylesheet" href="' . $path . '">';
		}
	}
	public function getHelpItem($key) {
		$UIHelpItem = $this->UIHelpItems[$key];
		return $UIHelpItem;
	}
	private function getID($key) {
		return $key . rand(1, 1000);
	}
}
class UIHelpItem {
	public $htmlPath = null;
	public $jsPath = null;
	public $cssPath = null;
	private $itemID = null;
	function __construct($path , $id) {
		$this->htmlPath = $GLOBALS["Project"] . "/body/blocks" . $path . ".php";
		$this->jsPath = $GLOBALS["Project"] . "/body/blocks" . $path . ".js";
		$this->cssPath = $GLOBALS["Project"] . "/body/blocks" . $path . ".css";
		$this->itemID = $id;
 	}
 	public function getHTMLPath() {
 		return $this->htmlPath;
 	}
 	public function getJSPath() {
 		return $this->jsPath;
 	}
 	public function getCSSPath() {
 		return $this->cssPath;
 	}
 	public function getBkID() {
 		return $this->itemID;
 	}
}
?>