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
		$orderPost = array(
        	"orderID" => $orderID,
            "showTranslate" => true
        	);
        $post["data"] = json_encode($orderPost ,true);
        // $orderViewAPI = "http://localhost:8888/www/En/api/module/order/view.php";
        $orderViewAPI = $domain . "/order/view.php";
        $httpForOrderView = new HttpWorker($orderViewAPI);
        $orderViewResult = $httpForOrderView->post($post);
        $orderObj = json_decode($orderViewResult,true)["data"];
		$data = array();
		$data["value"] = $orderObj;
		$data["message"] = 'Ok';
		$data["code"] = 0;
		return $data;
	}
}
?>