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
		shuffle($wordList);
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
				<h5 class="red-text text-lighten-1 custom-font-size" id="word-num-text">
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
		<?php
		if ($alreadyWord != $value["wordNum"]) {
			?>
			<div class="col s12">
				<div class="card-panel grey lighten-5 col s12">
					<h6 class="black-text">已選擇單字</h6>
					<?php
					for ($x=0; $x < count($list); $x++) {
						$item = $list[$x];
						$detailID = $item["detailID"];
						$enWord = $item["enWord"];
						?>
						<div class="card-panel text-card-panel grey lighten-5 left margin-rigth-10" id="box-<?php echo $x;?>">
							<a class="left waves-effect waves-light white" id="btn-<?php echo $x;?>" href="javascript: chooseBk.removeWord('<?php echo $detailID;?>',<?php echo $x;?>);">
								<i class="material-icons red-text text-darken-2">delete</i>
							</a>
							<code class="left"><?php echo $enWord;?></code>
						</div>
						<?php
					}
					?>
				</div>
			</div>
			<div class="clear"></div>
			<?php
			$index = 0;
			for ($i=0; $i < count($wordList); $i++) {
				$wordItem = $wordList[$i];
				$definitionList = $wordItem["definitionList"];
				$translateList = $wordItem["translateList"];
				$enWordID = $wordItem["enWordID"];
				$check = false;
				for ($x=0; $x < count($list); $x++) { 
					$item = $list[$x];
					if ($enWordID == $item["enWordID"]) {
						$check = true;
						break;
					}
				}
				if ($check ) continue;
				?>
				<div class="col s6">
					<div class="card-panel custom-card-panel grey lighten-5">
						<div class="col s12">
							<h6 class="blue-text text-darken-4">單字：<?php echo $wordItem["enWord"];?></h6>
							<?php
							$ditem = $definitionList[0];
							$titem = $translateList[0];
							?>
							<h6 class=" light-blue-text text-accent-4">
								詞性：<?php echo $ditem["enDefinition"];?>
								&nbsp;&nbsp;
								解釋：<?php echo $titem["enTranslate"];?>
							</h6>
							<h6 class="teal-text text-lighten-2">
								狀態：未選擇
							</h6>
						</div>
						<a class="btn-floating btn-large waves-effect waves-light teal lighten-1" href="javascript: chooseBk.addWord('<?php echo $orderID;?>','<?php echo $enWordID;?>',<?php echo $index;?>);" id="btn-<?php echo $index;?>">
							<i class="material-icons">add</i>
						</a>
						<div class="preloader-wrapper small active right" id="loader-<?php echo $index;?>">
							<div class="spinner-layer spinner-green-only">
								<div class="circle-clipper left">
									<div class="circle"></div>
								</div>
								<div class="gap-patch">
									<div class="circle"></div>
								</div>
								<div class="circle-clipper right">
									<div class="circle"></div>
								</div>
							</div>
						</div>
						<div class="clear"></div>
					</div>
				</div>
				<?php
				if ($index == 9 ) break;
				$index ++;			
			}
		} else {
			?>
			<div class="clear"></div>
			<h4>已經完成選擇單字！請按下下一步，開始背單字！</h4>
			<?php
		}	
	}
	?>
	<div class="clear"></div>
</div>
<!-- Modal Structure -->
<div id="message-modal" class="modal">
	<div class="modal-content">
		<h4>訊息</h4>
		<h5 id="message"></h5>
	</div>
	<div class="modal-footer">
		<a href="javascript: void(0)" class="modal-action modal-close waves-effect waves-green btn-flat">確定</a>
	</div>
</div>
