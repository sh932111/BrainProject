<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $Project . "/base/HttpWorker.php";
class memoryModules {
    public static function run($GET_value) {
    	$orderPost = array(
        	"orderID" => $orderID,
            "showTranslate" => true
        	);
        $post["data"] = json_encode($orderPost ,true);
        // $orderViewAPI = "http://localhost:8888/www/En/api/module/order/view.php";
        $orderViewAPI = "http://shared.tw/En/api/module/order/view.php";
        $httpForOrderView = new HttpWorker($orderViewAPI);
        $orderViewResult = $httpForOrderView->post($post);
        $orderObj = json_decode($orderViewResult,true)["data"];
    	return json_encode($orderObj ,true);
    }
}
?>