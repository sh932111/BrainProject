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
		label.innerHTML = "類別名稱";
		div.appendChild(input);
		div.appendChild(label);
		group[0].appendChild(div);
	};
	this.sendType = function() {
		var list = [];
		var group = ctrl.sel("#input-group");
		var listGroup = group[0].getElementsByTagName('input');
		for (var i = 0; i < listGroup.length; i++) {
			var input = listGroup[i];
			var value = input.value;
			if (value.length > 0) {
				var item = {
					enTypeName : value
				};
				list.push(item);
			}
		}
		var post = {
			list : list
		};
		var req = {
			url: "/en/type/create.php", 
			post: {
				data : JSON.stringify(post)
			} 
		}; 
		ctrl.api(req, function(response){ 
			var data = response.data;
			if (data.result) {
				alert(data.message);
				window.location.reload();
			}
			else {
				alert(data.message);
			}
		});
	};
};
