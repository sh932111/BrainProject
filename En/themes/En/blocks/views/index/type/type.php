<div class="card-panel grey lighten-3">
	<h5>類別管理</h5>
	<div class="card-panel grey lighten-4">
		<h5 class="left">新增類別</h5>
		<a class="btn-floating btn-large waves-effect waves-light red right" href="javascript: <?php echo $ctrl;?>.typeManagerBk.addType();">
			<i class="material-icons">add</i>
		</a>
		<div class="clear"></div>
	</div>
	<div class="card-panel">
		<div class="row" id="input-group">
			<div class="input-field col s6">
				<input id="type" type="text" class="validate">
				<label for="type">類別名稱</label>
			</div>
		</div>
		<a class="waves-effect waves-light btn right" href="javascript: <?php echo $ctrl;?>.typeManagerBk.sendType();">發送</a>
		<div class="clear"></div>
	</div>
</div>