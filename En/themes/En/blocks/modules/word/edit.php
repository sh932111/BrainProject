<?php 
class BlockModules {
	private $query = null; 
	function __construct($qy) {
		$this->query = $qy;
	}
	public function run() {
		$sitesParse = new SitesParse('/En');
		$domain = $sitesParse->getDomain();
		/*type list*/
		$wordView = $domain . "/en/word/view.php";
		$httpWorkerForWord = new HttpWorker($wordView);
		$post = array();
		$data = array(
			"enWordID" => $this->query['enWordID']
			);
		$post["data"] = json_encode($data ,true);
		$wordResult = $httpWorkerForWord->post($post);
        $wordObj = json_decode($wordResult,true);
        $word = $wordObj["data"];
		$data = array();
		$data["value"] = $word;
		$data["message"] = 'Ok';
		$data["code"] = 0;
		return $data;
	}
}
?>