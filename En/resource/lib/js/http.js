var typeCreate = "http://shared.tw/En/api/module/en/type/create.php";
var typeList = "http://shared.tw/En/api/module/en/type/list.php";
var wordCreate = "http://shared.tw/En/api/module/en/word/create.php";
var wordList = "http://shared.tw/En/api/module/en/word/list.php";
var wordView = "http://shared.tw/En/api/module/en/word/view.php";
var wordUpdate = "http://shared.tw/En/api/module/en/word/update.php";
var wordDelete = "http://shared.tw/En/api/module/en/word/delete.php";

function httpPost (url ,post , callback) {
	var post_data = {
		data : JSON.stringify(post)
	};
	$.post(url, post_data , function(response){
		var get_json = JSON.parse(response).data;
		callback(get_json);
	});
};