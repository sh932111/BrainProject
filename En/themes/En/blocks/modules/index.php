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
		$typeListAPI = $domain . "/en/type/list.php";
		$httpForType = new HttpWorker($typeListAPI);
        $typeResult  = $httpForType->post(array());
        $typeObj = json_decode($typeResult,true);
        $type = $typeObj["data"];
        /*word list*/
        $wordListAPI = $domain . "/en/word/list.php";
        $httpForWord = new HttpWorker($wordListAPI);
       	$post = array();
        if (!empty($this->query['enTypeID'])) {
            $postData = array(
                "enTypeID" => $this->query['enTypeID']
                );
            $post["data"] = json_encode($postData ,true);
        }
        $wordResult = $httpForWord->post($post);
        $wordObj 	= json_decode($wordResult,true);
        $word 		= $wordObj["data"];
        $wordList 	= $word["wordList"];
        $type["wordList"] = $wordList;
		$data = array();
		$data["value"] = $type;
		$data["message"] = 'Ok';
		$data["code"] = 0;
		return $data;
	}
}
?>