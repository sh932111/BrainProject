<?php
$GETenTypeID = $_GET["enTypeID"];
$data = json_decode($response,true);
$error_code = $data["error_code"];
if ($error_code == 0) {
	$value = $data["value"];
	$enWord = $value["enWord"];
	$enWordID = $value["enWordID"];
	$definitionList = $value["definitionList"];
	$exampleList = $value["exampleList"];
	$translateList = $value["translateList"];
?>
<div class="card-panel grey lighten-3">
	<h5 class="left">單字修改</h5>
	<div class="clear"></div>
	<div class="card-panel">
		<div class="row" id="input-group">
			<div class="input-field col s12">
				<input id="en-word-input" type="text" class="validate" value="<?php echo $enWord;?>">
				<label for="en-word-input">單字</label>
			</div>
			<?php
				for ($x=0; $x < count($definitionList); $x++) { 
					$ditem = $definitionList[$x];
					$eitem = $exampleList[$x];
					$titem = $translateList[$x];
			?>
			<div class="input-field col s2">
				<input id="definition-input<?php echo $x;?>" type="text" class="validate" value="<?php echo $ditem['enDefinition'];?>">
				<label for="definition-input<?php echo $x;?>">詞性</label>
				<span class="hide" id="definition<?php echo $x;?>"><?php echo $ditem['enDefinitionID'];?></span>
			</div>
			<div class="input-field col s2">
				<input id="translate-input<?php echo $x;?>" type="text" class="validate" value="<?php echo $titem['enTranslate'];?>">
				<label for="translate-input<?php echo $x;?>">解釋</label>
				<span class="hide" id="translate<?php echo $x;?>"><?php echo $titem['enTranslateID'];?></span>
			</div>
			<div class="input-field col s4">
				<input id="en-example-input<?php echo $x;?>" type="text" class="validate" value="<?php echo $eitem['enExample'];?>">
				<label for="en-example-input<?php echo $x;?>">例句</label>
				<span class="hide" id="en-example<?php echo $x;?>"><?php echo $eitem['enExampleID'];?></span>
			</div>
			<div class="input-field col s4">
				<input id="zh-example-input<?php echo $x;?>" type="text" class="validate" value="<?php echo $eitem['zhExample'];?>">
				<label for="zh-example-input<?php echo $x;?>">例句翻譯</label>
			</div>
			<?php	
				} 
			?>
		</div>
		<a class="waves-effect waves-light btn right" href="javascript: editWordBk.editWord('<?php echo $enWordID;?>');">修改</a>
		<div class="clear"></div>
	</div>
</div>
<?php	
} else {
?>
	<h4>取得資料失敗！</h4>
<?php		
}
?>

