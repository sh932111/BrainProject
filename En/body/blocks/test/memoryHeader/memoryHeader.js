var memoryHeaderBk;
function memoryHeaderBlock(id) {
	this.bkID = id;
};

function memoryHeaderBlockMain(bkID) {
	memoryHeaderBk = new memoryHeaderBlock(bkID);
};