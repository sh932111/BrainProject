<div class="row">
	<?php
	$data = json_decode($response,true);
	$list 	= $data["list"];
	shuffle($list);
	$error_code = $data["error_code"];
	if ($error_code == 0) {
		for ($i=0; $i < count($list); $i++) {
			$wordItem = $list[$i];
			$detailID = $wordItem["detailID"];
			$enWord = $wordItem["enWord"];
			$definitionList = $wordItem["definitionList"];
			$translateList = $wordItem["translateList"];
			?>
			<div class="row col s6 no-margin-bottom">
				<div class="card-panel grey lighten-5 col s12 custom-card">
					<div class="input-field col s12" id="<?php echo $detailID;?>">
						<input id="word<?php echo $i;?>" type="text" class="validate word-input">
						<label for="word<?php echo $i;?>">填入單字</label>
					</div>
					<?php
					for ($x=0; $x < count($definitionList); $x++) {
						$ditem = $definitionList[$x];
						$titem = $translateList[$x];
						?>
						<h5 class="col s3 custom-font-size">詞性：<?php echo $ditem["enDefinition"];?></h5>
						<h5 class="col s9 custom-font-size">解釋：<?php echo $titem["enTranslate"];?></h5>
						<?php
					}
					?>
					<a class="btn-floating yellow darken-4" href="javascript: testPageBk.sound(<?php echo $i;?>);">
						<i class="large material-icons">volume_up</i>
					</a>
					<form onsubmit="meSpeak.speak(text.value, { amplitude: 50, wordgap: 0, pitch: 100, speed: 140, variant: '' }); return false" hidden>
						<input type="text" name="text" size="80" value="<?php echo $enWord;?>">
						<input type="submit" id="speak<?php echo $i;?>">
					</form>
				</div>
				<div class="clear"></div>
			</div>
			<?php
		}
	}
	?>
	<div class="clear"></div>
	<div class="fixed-action-btn horizontal click-to-toggle" style="bottom: 45px; right:80px;">
		<a class="btn-floating btn-large red modal-trigger"  href="javascript: testPageBk.upload();" id="upload-btn">上傳</a>
		<div class="preloader-wrapper small active" id="upload-loader">
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
	</div>
</div>
<!-- Modal Structure -->
<div id="message-modal" class="modal">
	<div class="modal-content">
		<h4>訊息</h4>
		<h5>上傳成功！如確認無誤請點選交卷按鈕！</h5>
	</div>
	<div class="modal-footer">
		<a href="javascript: void(0)" class="modal-action modal-close waves-effect waves-green btn-flat">確定</a>
	</div>
</div>