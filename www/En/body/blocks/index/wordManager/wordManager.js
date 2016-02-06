var wordManagerBk;
function wordManagerBlock(id) {
	this.bkID = id;
	this.wordManagerList = [];
	this.typeID = "";
	this.initWord = function(type_id) {
		this.typeID = type_id;
	};
	this.addWord = function() {
		var word_manager = new wordManager(this.wordManagerList.length);
		this.wordManagerList.push(word_manager);
		var group = $("#word-group");
		group[0].appendChild(word_manager.getBox());
	};
	this.addConfig = function(word_index) {
		var wordRoot = this.wordManagerList[word_index];
		wordRoot.addWordBox();
	};
	this.sendWord = function() {
		var wordList = [];
		for (var i = 0; i < this.wordManagerList.length; i++) {
			var wordRoot = this.wordManagerList[i];
			var word = wordRoot.getWordValue();
			if (word.length == 0) return;
			var configList = [];
			var configManagerList = wordRoot.configManagerList;
			for (var x = 0; x < configManagerList.length; x++) {
				var configRoot = configManagerList[x];
				var def = configRoot.getDefinitionValue();
				if (def.length == 0) return;
				var tra = configRoot.getTranslateValue();
				if (tra.length == 0) return;
				var exa = configRoot.getExampleValue();
				var zhexa = configRoot.getZhExampleValue();
				var config_obj = {
					enDefinition : def ,
					enTranslate : tra,
					enExample : exa,
					zhExample : zhexa
				};
				configList.push(config_obj);
			}
			var word_obj = {
				enTypeID : this.typeID ,
				enWord : word ,
				configList : configList
			};
			wordList.push(word_obj);
		}
		var post = {
			wordList : wordList
		};
		httpPost(wordCreate,post,function(data){
			if (data.result) {
				alert(data.message);
				window.location.reload();
			}
			else {
				alert(data.message);
			}
		});
	};
	this.editWord = function(enWordID) {
		window.location.href = "../word/edit?enWordID=" + enWordID;
	};
	this.chooseType = function(enTypeID) {
		window.location.href = "./?enTypeID=" + enTypeID;
	}; 
};

function wordManager(root_id) {
	this.rootID = root_id;
	this.configManagerList = [];
	this.getBox = function() {
		var div  = document.createElement('div');
		div.className = "card-panel blue lighten-5";
		div.id = "word-box" + this.rootID;
		div.appendChild(getFieldGroup("word" + this.rootID , 11 , "單字"));
		div.appendChild(this.getAddWord());
		div.appendChild(this.getWordBox());
		div.appendChild(getClear());
		return div;
	};
	this.getAddWord = function() {
		var div  = document.createElement('div');
		div.className = "input-field col s1";
		var a  = document.createElement('a');
		a.className = "btn-floating btn-large waves-effect waves-light blue";
		a.setAttribute('href', 'javascript:wordManagerBk.addConfig(' + this.rootID + ');');
		var i  = document.createElement('i');
		i.className = "material-icons";
		i.innerHTML = "add";
		a.appendChild(i);
		div.appendChild(a);
		return div;
	};
	this.getWordBox = function() {
		var config_manager = new configManager(this.configManagerList.length , this.rootID);
		this.configManagerList.push(config_manager);
		var word_box = config_manager.getWord();
		word_box.appendChild(config_manager.getDefinition());
		word_box.appendChild(config_manager.getTranslate());
		word_box.appendChild(config_manager.getExample());
		word_box.appendChild(config_manager.getZhExample());
		return word_box;
	};
	this.addWordBox = function() {
		var id = "#word-config" + this.rootID;
		var group = $(id);
		var config_manager = new configManager(this.configManagerList.length , this.rootID);
		this.configManagerList.push(config_manager);
		group[0].appendChild(config_manager.getDefinition());
		group[0].appendChild(config_manager.getTranslate());
		group[0].appendChild(config_manager.getExample());
		group[0].appendChild(config_manager.getZhExample());
	};
	this.getWordValue = function() {
		var id = "#word" + this.rootID;
		var field = $(id);
		var value = field.val();
		if (value.length == 0) {
			alert("單字不能為空！");
			field.focus();
		}
		return value;
	};
};

function configManager(config_id ,root_id ) {
	this.configID = config_id;
	this.rootID = root_id;
	this.getWord = function() {
		var div  = document.createElement('div');
		div.id = "word-config" + this.rootID;
		return div;
	};
	this.getDefinition = function() {
		var id = "definition" + this.rootID + this.configID;
		return getFieldGroup(id , 2 , "詞性");
	};
	this.getTranslate = function() {
		var id = "translate" + this.rootID + this.configID;
		return getFieldGroup(id , 2 , "解釋");
	};
	this.getExample = function() {
		var id = "example" + this.rootID + this.configID;
		return getFieldGroup(id , 4 , "例句");
	};
	this.getZhExample = function() {
		var id = "zh-example" + this.rootID + this.configID;
		return getFieldGroup(id , 4 , "例句翻譯");
	};
	this.getDefinitionValue = function() {
		var id = "#definition" + this.rootID + this.configID;
		var field = $(id);
		var value = field.val();
		if (value.length == 0) {
			alert("詞性不能為空！");
			field.focus();
		}
		return value;
	};
	this.getTranslateValue = function() {
		var id = "#translate" + this.rootID + this.configID;
		var field = $(id);
		var value = field.val();
		if (value.length == 0) {
			alert("解釋不能為空！");
			field.focus();
		}
		return value;
	};
	this.getExampleValue = function() {
		var id = "#example" + this.rootID + this.configID;
		var field = $(id);
		var value = field.val();
		return value;
	};
	this.getZhExampleValue = function() {
		var id = "#zh-example" + this.rootID + this.configID;
		var field = $(id);
		var value = field.val();
		return value;
	};
};

function getFieldGroup(id , width , text) {
	var div  = document.createElement('div');
	div.className = "input-field col s" + width;
	var input  = document.createElement('input');
	input.setAttribute("id", id);
	input.setAttribute("type", "text");
	input.className = "validate";
	var label  = document.createElement('label');
	label.setAttribute("for", id);
	label.innerHTML = text;
	div.appendChild(input);
	div.appendChild(label);
	return div;
};

function getClear() {
	var div  = document.createElement('div');
	div.className = "clear";
	return div;
};

function wordManagerBlockMain(bkID) {
	wordManagerBk = new wordManagerBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	var get = manager.getGET();
	if (get) {
		wordManagerBk.initWord(get);
		wordManagerBk.addWord();
	}
	$('#dropdown-btn-type').dropdown({
		inDuration: 300,
		outDuration: 225,
		constrain_width: false,
		gutter: 0, 
		belowOrigin: false
	});
	$('#modal-trigger').leanModal();
};