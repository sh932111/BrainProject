<div class="row">
	<?php
	$orderID = $_GET["orderID"];
	$response_decode = json_decode($response,true);
	$data 	= $response_decode["data"];
	$order 	= $response_decode["order"];
	$list 	= $order["list"];
	$value 	= $order["value"];
	$error_code = $data["error_code"];
	if ($error_code == 0) {
		$wordList = $data["wordList"];
		$alreadyWord = count($list);
		?>
		<div class="col s12">
			<div class="card-panel custom-card-panel grey lighten-5 col s7">
				<h5 class="black-text custom-title-font-size">測試資訊</h5>
				<h6 class="brown-text text-darken-1">
					測試者：<?php echo $value["userName"];?>
					&nbsp;&nbsp;
					年紀：<?php echo $value["userYearOld"];?>&nbsp;歲
				</h6>
				<h6 class="brown-text text-lighten-1">
					單字數：<?php echo $value["wordNum"];?>&nbsp;個
					&nbsp;&nbsp;
					測驗時間：<?php echo $value["testTime"];?>&nbsp;秒
				</h6>
				<h5 class="red-text text-lighten-1 custom-font-size">
					已選擇：<?php echo $alreadyWord?>個單字
					<?php
						if ($alreadyWord == $value["wordNum"]) {
					?>
						，如已經確認完畢，請按下上方送出按鈕！
					<?php	
						}
					?>
				</h5>
			</div>
		</div>
		<div class="clear"></div>
		<?php
		for ($i=0; $i < count($wordList); $i++) {
			$wordItem = $wordList[$i];
			$definitionList = $wordItem["definitionList"];
			$translateList = $wordItem["translateList"];
			?>
			<div class="col s6">
				<div class="card-panel custom-card-panel grey lighten-5">
					<div class="col s12">
						<h6 class="blue-text text-darken-4">單字：<?php echo $wordItem["enWord"];?></h6>
						<?php
						for ($x=0; $x < count($definitionList); $x++) {
							$ditem = $definitionList[$x];
							$titem = $translateList[$x];
							?>
							<h6 class=" light-blue-text text-accent-4">
								詞性：<?php echo $ditem["enDefinition"];?>
								&nbsp;&nbsp;
								解釋：<?php echo $titem["enTranslate"];?>
							</h6>	
							<?php
						}
						?>
						<?php
						$pkCheck = false;
						$pkWordID = $wordItem["enWordID"];
						$detailID = "";
						for ($x=0; $x < count($list); $x++) {
							$item = $list[$x];
							$enWordID = $item["enWordID"];
							if ($enWordID == $pkWordID) {
								$pkCheck = true;
								$detailID = $item["detailID"];
								break;
							}
						}
						if ($pkCheck) {
							?>
							<h6 class="red-text text-lighten-2">
								狀態：已選擇
							</h6>
						</div>
						<a class="btn-floating btn-large waves-effect waves-light red lighten-1" href="javascript: chooseBk.removeWord('<?php echo $detailID;?>');">
							<i class="material-icons">remove</i>
						</a>
						<?php
					}
					else {
						?>
						<h6 class="teal-text text-lighten-2">
							狀態：未選擇
						</h6>
					</div>
					<a class="btn-floating btn-large waves-effect waves-light teal lighten-1" href="javascript: chooseBk.addWord('<?php echo $orderID;?>','<?php echo $pkWordID;?>');">
						<i class="material-icons">add</i>
					</a>
					<?php
				}
				?>
				<div class="clear"></div>
			</div>
		</div>
		<?php			
	}	
}
?>
<div class="clear"></div>
</div>