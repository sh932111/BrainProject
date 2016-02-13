<div class="row">
	<div class="col s12">
		<div class="card style-color">
			<div class="card-content" id="word-box">
				<h3 class="grey-text text-lighten-3 word-title left" id="learn-word"></h3>
				<a class="btn-floating btn-large yellow darken-4 left" href="javascript: memoryBk.sound();">
					<i class="large material-icons">volume_up</i>
				</a>
				<a class="btn grey lighten-3 style-text-color right" href="javascript: memoryBk.google();">Google</a>
				<a class="btn grey lighten-3 style-text-color right margin-right-10" href="javascript: memoryBk.doTest();" id="self-test">自行測試</a>
				<div class="clear"></div>
			</div>
			<div class="card-action" id="do-test">
				<h4 class="grey-text text-lighten-3 word-title">測試模式</h4>
				<div class="input-field col s6">
					<input placeholder="請拼出單字" id="write-input" type="text" class="validate">
					<label for="write-input">拼出單字</label>
				</div>
				<a class="btn-floating btn-large yellow darken-4 left" href="javascript: memoryBk.sound();">
					<i class="large material-icons">volume_up</i>
				</a>
				<a class="btn grey lighten-3 style-text-color right" href="javascript: memoryBk.hideTest();">忘記了</a>
				<a class="btn grey lighten-3 style-text-color right margin-right-10" href="javascript: memoryBk.confirm();">確認答案</a>
				<div class="clear"></div>
			</div>
			<div class="card-action">
				<h5 class="yellow-text text-lighten-4" id="config-word"></h5>
			</div>
			<div class="card-action white-text" id="example-box">
				<h4>例句：</h4>
				<h5 id="en-example"></h5>
				<h5 id="zh-example"></h5>
			</div>
			<div class="card-action">
				<div id="left-controller" class="left">
					<a class="waves-effect waves-light btn left grey lighten-3" href="javascript: memoryBk.back();">
						<i class="large material-icons style-text-color">fast_rewind</i>
					</a>
					<span class="card-title left white-text">&nbsp;上一個</span>
				</div>
				<div id="right-controller" class="right">
					<a class="waves-effect waves-light btn right grey lighten-3" href="javascript: memoryBk.next();">
						<i class="large material-icons style-text-color">fast_forward</i>
					</a>
					<span class="card-title right white-text">下一個&nbsp;</span>
				</div>
				<div class="clear"></div>
			</div>
		</div>
	</div>
</div>
<form onsubmit="meSpeak.speak(text.value, { amplitude: 50, wordgap: 0, pitch: 100, speed: 140, variant: '' }); return false" hidden>
	<input type="text" name="text" size="80" id="word-input">
	<input type="submit" id="speak">
</form>
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
