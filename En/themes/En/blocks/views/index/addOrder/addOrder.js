ctrl.typeManagerBk;
ctrl.startup = function() {
	ctrl.typeManagerBk = new ctrl.typeManagerBlock();
};

ctrl.typeManagerBlock = function() {
	this.addType = function() {
		var group = ctrl.sel("#input-group");
		var div  = document.createElement('div');
		div.className = "input-field col s6";
		var input  = document.createElement('input');
		input.setAttribute("id", "type");
		input.setAttribute("type", "text");
		input.className = "validate";
		var label  = document.createElement('label');
		label.setAttribute("for", 'type');
		label.innerHTML = "單字ID";
		div.appendChild(input);
		div.appendChild(label);
		group[0].appendChild(div);
	};
	this.sendType = function() {
		if (ctrl.sel("#order-id-input").val().length == 0) {
			alert('尚未填入單字表ID');
			return;
		}
		var list = [];
		var group = ctrl.sel("#input-group");
		var listGroup = group[0].getElementsByTagName('input');
		for (var i = 0; i < listGroup.length; i++) {
			var input = listGroup[i];
			var value = input.value;
			if (value.length > 0) {
				var item = {
					enWordID : value
				};
				list.push(item);
			}
		}
		var index = 0;
		for (var i = 0; i < list.length; i++) {
			var post = list[i];
			post.orderID = ctrl.sel("#order-id-input").val();
			var req = {
				url: "/order/createWord.php", 
				post: {
					data : JSON.stringify(post)
				} 
			};
			ctrl.api(req, function(response){ 
				var data = response.data;
				if (data.result) {
					index ++;
					if (index == list.length - 1) {
						alert('新增成功！');
						window.location.reload();
					}
				}
			});
		}
	};
};
