function settingChange(labelID) {
    document.getElementById(labelID).innerHTML = 'Changed - Not Saved';
    document.getElementById(labelID).className = 'label label-warning animated pulse noCurves';
}
