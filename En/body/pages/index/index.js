var indexPg;
function indexPage() {
};

function indexMain() {
	indexPg = new indexPage();
	var post = {
		orderID : "201602070002568216"
	};
	httpPost(orderView,post,function(data){
		console.log(data);
	});
};