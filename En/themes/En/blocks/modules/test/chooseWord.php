<?php 
class BlockModules {
	private $query = null; 
	function __construct($qy) {
		$this->query = $qy;
	}
	public function run() {
		$orderID = $this->query["orderID"];
		$sitesParse = new SitesParse('/En');
		$domain = $sitesParse->getDomain();
		$wordListAPI = $domain . "/en/word/list.php";
    	$httpWorkerForWord = new HttpWorker($wordListAPI);
        $post = array();
        $wordResult = $httpWorkerForWord->post($post);
        $wordObj = json_decode($wordResult,true);
        $orderData = array(
        	"orderID" => $orderID,
            "showTranslate" => true
        	);
        $orderViewAPI = $domain . "/order/view.php";
        $orderPost["data"] = json_encode($orderData ,true);
        $httpForOrderView = new HttpWorker($orderViewAPI);
        $orderViewResult = $httpForOrderView->post($orderPost);
        $orderObj = json_decode($orderViewResult,true)["data"];
        $list = $orderObj["list"];
        $value = $orderObj["value"];
        $wordObj["order"]["list"] = $list;
        $wordObj["order"]["value"] = $value;
        $data["value"] = $wordObj;
    	$data["message"] = 'Ok';
		$data["code"] = 0;
		return $data;
	}
}
?>