var editWordBk;
function editWordBlock(id) {
	this.bkID = id;
	this.configIndex = -1;
	this.editWord = function(enWordID) {
		var enWord = $("#en-word-input").val();
		var definitionList = [];
		var translateList = [];
		var exampleList = [];
		for (var i = 0; i < this.configIndex; i++) {
			var enDefinitionID = $("#definition" + i).html();
			var enDefinition = $("#definition-input" + i).val();
			var definition = {
				enDefinitionID : enDefinitionID,
				enDefinition : enDefinition
			};
			definitionList.push(definition);
			var enTranslateID = $("#translate" + i).html();
			var enTranslate = $("#translate-input" + i).val();
			var translate = {
				enTranslateID : enTranslateID,
				enTranslate : enTranslate
			};
			translateList.push(translate);
			var enExampleID = $("#en-example" + i).html();
			var enExample = $("#en-example-input" + i).val();
			var zhExample = $("#zh-example-input" + i).val();
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
		httpPost(wordUpdate,post,function(data){
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

function editWordBlockMain(bkID) {
	editWordBk = new editWordBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	if (api.error_code == 0) {
		var value = api.value;
		var definitionList = value.definitionList;
		editWordBk.initConfig(definitionList.length);
	}
};