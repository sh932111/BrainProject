<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $Project . "/base/HttpWorker.php";
class chooseModules {
    public static function run($orderID) {
    	$wordListAPI = "http://localhost:8888/www/En/api/module/en/word/list.php";
    	// $wordListAPI = "http://shared.tw/En/api/module/en/word/list.php";
    	$httpWorkerForWord = new HttpWorker($wordListAPI);
        $post = array();
        $wordResult = $httpWorkerForWord->post($post);
        $wordObj = json_decode($wordResult,true);
        $orderData = array(
        	"orderID" => $orderID
        	);
        $orderViewAPI = "http://localhost:8888/www/En/api/module/order/view.php";
        // $orderViewAPI = "http://shared.tw/En/api/module/order/view.php";
        $orderPost["data"] = json_encode($orderData ,true);
        $httpForOrderView = new HttpWorker($orderViewAPI);
        $orderViewResult = $httpForOrderView->post($orderPost);
        $orderObj = json_decode($orderViewResult,true)["data"];
        $list = $orderObj["list"];
        $value = $orderObj["value"];
        $wordObj["order"]["list"] = $list;
        $wordObj["order"]["value"] = $value;
    	return json_encode($wordObj ,true);
    }
}
?>