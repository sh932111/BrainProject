<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $Project . "/base/HttpWorker.php";
class editWordModules {
	public static function run($GET_value) {
		$wordView = "http://localhost:8888/www/En/api/module/en/word/view.php";
		// $wordView = "http://shared.tw/En/api/module/en/word/view.php";
		$httpWorkerForWord = new HttpWorker($wordView);
		$post = array();
		$data = array(
			"enWordID" => $GET_value
			);
		$post["data"] = json_encode($data ,true);
		$wordResult = $httpWorkerForWord->post($post);
        $wordObj = json_decode($wordResult,true);
        $word = $wordObj["data"];
        return json_encode($word ,true);
	}
}
?>