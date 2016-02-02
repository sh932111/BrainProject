<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $Project . "/base/HttpWorker.php";
class wordManagerModules {
    public static function run($GET_value) {
        $httpWorkerForType = new HttpWorker("http://shared.tw/En/api/module/en/type/list.php");
        $typeResult = $httpWorkerForType->post(array());
        $typeObj = json_decode($typeResult,true);
        $type = $typeObj["data"];
        $httpWorkerForWord = new HttpWorker("http://shared.tw/En/api/module/en/word/list.php");
        $post = array();
        if (!empty($GET_value)) {
            $data = array(
                "enTypeID" => $GET_value
                );
            $post["data"] = json_encode($data ,true);
        }
        $wordResult = $httpWorkerForWord->post($post);
        $wordObj = json_decode($wordResult,true);
        $word = $wordObj["data"];
        $wordList = $word["wordList"];
        $type["wordList"] = $wordList;
        return json_encode($type ,true);
    }
}
?>