var testHeaderBk;
function testHeaderBlock(id) {
	this.bkID = id;
};

function testHeaderBlockMain(bkID) {
	testHeaderBk = new testHeaderBlock(bkID);
};