function validMoney(cMoney) {
    var zs = /^[0-9]*[1-9][0-9]*$/;
    if (zs.test(cMoney)) {
        return true;
    }
    else {
        var r = /^\\d+(\\.\\d+)?$/;
        return r.test(cMoney);
    }
}