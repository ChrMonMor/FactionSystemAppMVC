// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function TagDetailsPopup()
{
    var select = document.getElementById('createFactionTagList');
    var value = select.selectedIndex;
    if (value > -1) {
        window.open('/Faction/TagDetails/' + value, "PopupWindow", 'width=600px,height=600px,top=150,left=250');
    }
}

function AddAssetToNewFactionList() {
    var selectList = document.getElementById('createFactionAssetList');
    var selectedList = document.getElementById('selectedFactionAssetList');
    selectedList.options[selectedList.options.length] = new Option(selectList[selectList.selectedIndex].id +" "+ selectList[selectList.selectedIndex].text, selectList[selectList.selectedIndex].value);
}

function RemoveAssetToNewFactionList() {
    var select = document.getElementById("selectedFactionAssetList");
    select.options[select.options.length - 1] = null;
}