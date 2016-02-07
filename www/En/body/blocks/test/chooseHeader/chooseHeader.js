var chooseHeaderBk;
function chooseHeaderBlock(id) {
	this.bkID = id;
};

function chooseHeaderBlockMain(bkID) {
	chooseHeaderBk = new chooseHeaderBlock(bkID);
};