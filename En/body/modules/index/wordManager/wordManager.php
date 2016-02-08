<?php
$Project = split("/body/pages",$_SERVER[PHP_SELF])[0];
include $Project . "/base/HttpWorker.php";
class wordManagerModules {
    public static function run($GET_value) {
        // $typeListAPI = "http://localhost:8888/www/En/api/module/en/type/list.php";
        $typeListAPI = "http://shared.tw/En/api/module/en/type/list.php";
        $httpWorkerForType = new HttpWorker($typeListAPI);
        $typeResult = $httpWorkerForType->post(array());
        $typeObj = json_decode($typeResult,true);
        $type = $typeObj["data"];
        // $wordListAPI = "http://localhost:8888/www/En/api/module/en/word/list.php";
        $wordListAPI = "http://shared.tw/En/api/module/en/word/list.php";
        $httpWorkerForWord = new HttpWorker($wordListAPI);
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