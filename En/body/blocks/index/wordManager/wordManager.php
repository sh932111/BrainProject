<?php
$GETenTypeID = $_GET["enTypeID"];
$data = json_decode($response,true);
$error_code = $data["error_code"];
if ($error_code == 0) {
	$list = $data["list"];
	$wordList = $data["wordList"];
?>	
<div class="card-panel grey lighten-3">
	<h5 class="left">單字管理</h5>
	<!-- Dropdown Trigger -->
	<a class='dropdown-button btn right blue lighten-1' href='javascript: void(0)' id="dropdown-btn-type" data-activates='dropdown-type'>
	<?php
		$pointTypeName = "全部單字";
		if (!empty($GETenTypeID)) {
			for ($i=0; $i < count($list); $i++) { 
				$item = $list[$i];
				$enTypeName = $item["enTypeName"];
				$enTypeID = $item["enTypeID"];
				if ($GETenTypeID == $enTypeID) {
					$pointTypeName = $enTypeName;
					echo $enTypeName;
					break;
				}
			}
		}
		else {
			echo "選擇類別";
		}
	?>
	</a>
	<!-- Modal Trigger -->
  	<a class="waves-effect waves-light btn modal-trigger right amber darken-3" href="#modal-word" id="modal-trigger">查看單字</a>
	<!-- Dropdown Structure -->
	<ul id='dropdown-type' class='dropdown-content'>
		<?php
			for ($i=0; $i < count($list); $i++) { 
				$item = $list[$i];
				$enTypeName = $item["enTypeName"];
				$enTypeID = $item["enTypeID"];
		?>
		<li>
			<a href="javascript: wordManagerBk.chooseType('<?php echo $enTypeID;?>');"><?php echo $enTypeName;?></a>
		</li>
		<?php
			}
		?>
	</ul>
	<div class="clear"></div>
	<?php
	if (!empty($GETenTypeID)) {
	?>
	<div class="card-panel grey lighten-4">
		<h5 class="left">新增單字</h5>
		<a class="btn-floating btn-large waves-effect waves-light red right" href="javascript: wordManagerBk.addWord();">
			<i class="material-icons">add</i>
		</a>
		<div class="clear"></div>
	</div>
	<div class="card-panel">
		<div class="row" id="word-group"></div>
		<a class="waves-effect waves-light btn right" href="javascript: wordManagerBk.sendWord();">發送</a>
		<div class="clear"></div>
	</div>
	<?php } ?>
</div>
<!-- Modal Structure -->
<div id="modal-word" class="modal">
    <div class="modal-content">
      	<h4><?php echo $pointTypeName;?></h4>
      	<?php
			for ($i=0; $i < count($wordList); $i++) { 
				$item = $wordList[$i];
				$enWord = $item["enWord"];
				$enWordID = $item["enWordID"];
				$definitionList = $item["definitionList"];
				$exampleList = $item["exampleList"];
				$translateList = $item["translateList"];
		?>
	    <hr>
      	<table class="striped">
	        <thead>
	          	<tr>
	              	<th colspan="4">
	              		<h5 class="left"><?php echo $enWord;?></h5>
	              		<a class="btn-floating btn-small waves-effect waves-light grey lighten-1 right" href="javascript: wordManagerBk.editWord('<?php echo $enWordID;?>');" id="edit-btn">
							<i class="material-icons">description</i>
						</a>
						<div class="clear"></div>
	              	</th>
	         	</tr>
	        </thead>
	        <tbody>
	        	<?php
					for ($x=0; $x < count($definitionList); $x++) { 
						$ditem = $definitionList[$x];
						$eitem = $exampleList[$x];
						$titem = $translateList[$x];
				?>
	        	<tr class="row">
	            	<td class="col s1"><h6><?php echo $ditem["enDefinition"];?></h6></td>
	            	<td class="col s2"><h6><?php echo $titem["enTranslate"];?></h6></td>
	            	<td class="col s5"><h6><?php echo $eitem["enExample"];?></h6></td>
	            	<td class="col s4"><h6><?php echo $eitem["zhExample"];?></h6></td>
	          	</tr>
			    <?php
			    	}
			    ?>
	        </tbody>
	    </table>
	    <?php
	    	}
	    	if (count($wordList) == 0) {
	    ?>
	    	<h5>尚無單字資料！</h5>
	    <?php		
	    	}
	    ?>
    </div>
    <div class="modal-footer">
      	<a href="javascript: void(0)" class=" modal-action modal-close waves-effect waves-green btn-flat">關閉</a>
    </div>
</div>
<?php	
} else {
?>
	<h4>取得資料失敗！</h4>
<?php		
}
?>
