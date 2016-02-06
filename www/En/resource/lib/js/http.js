// var typeCreate = "http://shared.tw/En/api/module/en/type/create.php";
// var typeList = "http://shared.tw/En/api/module/en/type/list.php";
// var wordCreate = "http://shared.tw/En/api/module/en/word/create.php";
// var wordList = "http://shared.tw/En/api/module/en/word/list.php";
// var wordView = "http://shared.tw/En/api/module/en/word/view.php";
// var wordUpdate = "http://shared.tw/En/api/module/en/word/update.php";
// var wordDelete = "http://shared.tw/En/api/module/en/word/delete.php";
// var orderCreateWord = "http://shared.tw/En/api/module/order/createWord.php";
// var orderListWord = "http://shared.tw/En/api/module/order/listWord.php";
// var orderDeleteWord = "http://shared.tw/En/api/module/order/deleteWord.php";
// var orderUpdateWord = "http://shared.tw/En/api/module/order/updateWord.php";
// var orderCheckout = "http://shared.tw/En/api/module/order/checkout.php";
// var orderFinish = "http://shared.tw/En/api/module/order/finish.php";
// var orderView = "http://shared.tw/En/api/module/order/view.php";
var typeCreate = "http://localhost:8888/www/En/api/module/en/type/create.php";
var typeList = "http://localhost:8888/www/En/api/module/en/type/list.php";
var wordCreate = "http://localhost:8888/www/En/api/module/en/word/create.php";
var wordList = "http://localhost:8888/www/En/api/module/en/word/list.php";
var wordView = "http://localhost:8888/www/En/api/module/en/word/view.php";
var wordUpdate = "http://localhost:8888/www/En/api/module/en/word/update.php";
var wordDelete = "http://localhost:8888/www/En/api/module/en/word/delete.php";
var orderCreateWord = "http://localhost:8888/www/En/api/module/order/createWord.php";
var orderListWord = "http://localhost:8888/www/En/api/module/order/listWord.php";
var orderDeleteWord = "http://localhost:8888/www/En/api/module/order/deleteWord.php";
var orderUpdateWord = "http://localhost:8888/www/En/api/module/order/updateWord.php";
var orderCheckout = "http://localhost:8888/www/En/api/module/order/checkout.php";
var orderFinish = "http://localhost:8888/www/En/api/module/order/finish.php";
var orderView = "http://localhost:8888/www/En/api/module/order/view.php";

function httpPost (url ,post , callback) {
	var post_data = {
		data : JSON.stringify(post)
	};
	$.post(url, post_data , function(response){
		var get_json = JSON.parse(response).data;
		callback(get_json);
	});
};