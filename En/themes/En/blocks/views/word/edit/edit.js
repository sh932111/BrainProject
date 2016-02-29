ctrl.startup = function() {
	ctrl.editWordBk = new ctrl.editWordBlock();
	var api = ctrl.getAPI();
	if (api.code == 0) {
		var value = api.value.value;
		var definitionList = value.definitionList;
		ctrl.editWordBk.initConfig(definitionList.length);
	}
};

ctrl.editWordBk;
ctrl.editWordBlock = function() {
	this.configIndex = -1;
	this.editWord = function(enWordID) {
		var enWord = $("#en-word-input").val();
		var definitionList = [];
		var translateList = [];
		var exampleList = [];
		for (var i = 0; i < this.configIndex; i++) {
			var enDefinitionID = ctrl.sel("#definition" + i).html();
			var enDefinition = ctrl.sel("#definition-input" + i).val();
			var definition = {
				enDefinitionID : enDefinitionID,
				enDefinition : enDefinition
			};
			definitionList.push(definition);
			var enTranslateID = ctrl.sel("#translate" + i).html();
			var enTranslate = ctrl.sel("#translate-input" + i).val();
			var translate = {
				enTranslateID : enTranslateID,
				enTranslate : enTranslate
			};
			translateList.push(translate);
			var enExampleID = ctrl.sel("#en-example" + i).html();
			var enExample = ctrl.sel("#en-example-input" + i).val();
			var zhExample = ctrl.sel("#zh-example-input" + i).val();
			var example = {
				enExampleID : enExampleID,
				enExample : enExample,
				zhExample : zhExample
			};
			exampleList.push(example);
		}
		var post = {
			enWord : enWord ,
			enWordID : enWordID ,
			definitionList : definitionList,
			translateList : translateList,
			exampleList : exampleList
		};
		var req = {
			url: "/en/word/update.php", 
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
	this.initConfig = function(index) {
		this.configIndex = index;
	};
};
