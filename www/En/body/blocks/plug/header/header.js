var headerBk;
function headerBlock(id) {
	this.bkID = id;
};

function headerBlockMain(bkID) {
	headerBk = new headerBlock(bkID);
};