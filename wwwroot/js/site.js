"use strict";

var _this = void 0;

function _toConsumableArray(arr) { return _arrayWithoutHoles(arr) || _iterableToArray(arr) || _nonIterableSpread(); }

function _nonIterableSpread() { throw new TypeError("Invalid attempt to spread non-iterable instance"); }

function _iterableToArray(iter) { if (Symbol.iterator in Object(iter) || Object.prototype.toString.call(iter) === "[object Arguments]") return Array.from(iter); }

function _arrayWithoutHoles(arr) { if (Array.isArray(arr)) { for (var i = 0, arr2 = new Array(arr.length); i < arr.length; i++) { arr2[i] = arr[i]; } return arr2; } }

var contentNode;

var addNode = function addNode() {
  contentNode = document.getElementById('content');
};

var minusAction = function minusAction(el) {
  if (!contentNode) addNode();
  var bars = contentNode.getElementsByClassName('bar');
  if (el.parentNode.id === 'last-bar') bars[bars.length - 2].id = 'last-bar';
  contentNode.removeChild(el.parentNode);
  if (bars.length === 1) bars[0].className += ' onlyOne';
  visualizeQueryFilter();
};

var checkboxChange = function checkboxChange(checkbox) {
  checkbox.parentNode.className = checkbox.parentNode.className === "notBuilder" ? "notBuilderNotSelected" : "notBuilder";
};

var visualizeQueryFilter = function visualizeQueryFilter() {
  var bars = document.getElementsByClassName("bar");
  var data = Object.keys(bars).map(function(d) { return bars[d];}).reduce(function (viable, bar) {
    if (bar.childNodes[2].value !== '') {
      viable.push({
        not: bar.childNodes[0].childNodes[1].checked,
        select: bar.childNodes[1].value,
        input: bar.childNodes[2].value
      });
    }

    return viable;
  }, []);
  var ands = data.reduce(function (arr, current) {
    if (current.not) {
      arr.push("(".concat(current.select, " !~ ").concat(current.input, ")"));
    }

    return arr;
  }, []).join(' AND ');
  var ors = data.reduce(function (arr, current) {
    if (!current.not) {
      arr.push("(".concat(current.select, " ~ ").concat(current.input, ")"));
    }

    return arr;
  }, []).join(' OR ');
  var visualizationBox = document.getElementById('queryResult');
  visualizationBox.textContent = "".concat(ands).concat(ands.length > 0 && ors.length > 0 ? ' AND ' : ' ').concat(ors);
};

var plusAction = function plusAction() {
  if (!contentNode) addNode();
  var child = document.createElement('div');
  child.className = 'bar';
  var not = document.createElement('label');
  not.className = 'notBuilderNotSelected';
  not.addEventListener('click', function (event) {
    var target = event.target;
    if (target.tagName !== 'INPUT') return;
    checkboxChange(target);
  }, true);
  var hackCheck = document.createElement('input');
  hackCheck.type = 'hidden';
  hackCheck.value = 'off';
  hackCheck.name = 'nots';
  var check = document.createElement('input');
  check.type = 'checkbox';
  check.name = 'nots';
  not.appendChild(hackCheck);
  not.appendChild(check);
  not.innerHTML += " Not";
  var select = document.createElement('select');
  select.name = 'selects';
  var options = ["Sequence name", "Genbank id", "Journal", "Article", "Taxon", "Species"];
  options.forEach(function (text) {
    var option = document.createElement('option');
    option.textContent = text;
    select.appendChild(option);
  });
  var input = document.createElement('input');
  input.className = "textInput";
  input.name = 'inputs';

  var _createButtons = createButtons(),
    minusButton = _createButtons.minusButton,
    plusButton = _createButtons.plusButton;

  child.appendChild(not);
  child.appendChild(select);
  child.appendChild(input);
  child.appendChild(minusButton);
  child.appendChild(plusButton);
  child.id = 'last-bar';
  document.getElementById('last-bar').removeAttribute('id');
  var bars = contentNode.getElementsByClassName('bar');

  if (bars.length === 1) {
    bars[0].className = 'bar';
  }

  child.addEventListener('change', visualizeQueryFilter);
  contentNode.appendChild(child);
};

var createButtons = function createButtons() {
  var minusButton = document.createElement('button');

  minusButton.onclick = function () {
    minusAction(this);
  };

  minusButton.textContent = '-';
  minusButton.className = 'minus-button';
  minusButton.type = 'button';
  var plusButton = document.createElement('button');
  plusButton.textContent = '+';
  plusButton.className = 'plus-button';
  plusButton.onclick = plusAction;
  plusButton.type = 'button';
  return {
    minusButton: minusButton,
    plusButton: plusButton
  };
};

var sendAdvancedSearchForm = function sendAdvancedSearchForm() {
  var bars = document.getElementsByClassName("bar");

  Object.keys(bars).map(function (d) { return bars[d]; }).forEach(function (bar) {
    if (bar.childNodes[0].childNodes[1].checked) {
      bar.childNodes[0].childNodes[0].disabled = true;
    }
  });
  var BuilderSubmit = document.getElementById("AdvancedSearchButton");
  BuilderSubmit.click();
};

var selectRow = function selectRow(row) {
  row.className = row.className === "tableRow" ? "selectedRow" : "tableRow";
  document.getElementById("fastaDownloadButton").textContent = "Download ".concat(document.getElementsByClassName("selectedRow").length, " selected file(s) in zip");
};

var downloadSequences = function downloadSequences() {
  var selectedRows = document.getElementsByClassName("selectedRow");

  var ids = _toConsumableArray(selectedRows).map(function (row) {
    return row.id;
  });

  var idsString = ids.join(",");

  if (idsString !== "") {
    var aElement = document.getElementById("downloadMultipleLink");
    aElement.href = "/api/getSequences?sequenceGenbank=".concat(idsString);
    aElement.click();
  }
};

var downloadMetadata = function downloadMetadata() {
  var selectedRows = document.getElementsByClassName("selectedRow");

  var ids = _toConsumableArray(selectedRows).map(function (row) {
    return row.id;
  });

  var idsString = ids.join(",");

  if (idsString !== "") {
    var aElement = document.getElementById("downloadMetadata");
    aElement.href = "/api/getMetadata?sequenceGenbank=".concat(idsString);
    aElement.click();
  }
};

var selectAllRows = function selectAllRows() {
  _toConsumableArray(document.getElementsByClassName("tableRow")).forEach(selectRow);
};

var unselectAllRows = function unselectAllRows() {
  _toConsumableArray(document.getElementsByClassName("selectedRow")).forEach(selectRow);
};

var getStringFromFile = function getStringFromFile(evt) {
  var file = evt.target.files[0];
  var paste = document.getElementById('sequence');
  var output = document.getElementById('sequenceFileString');
  var sequence = "";

  if (file) {
    var reader = new FileReader();

    reader.onload = function () {
      sequence = reader.result;
      output.value = sequence.replace("'", "''");

      if (sequence !== "") {
        paste.value = "";
        paste.disabled = true;
      }
    };

    reader.readAsText(file);
  } else {
    paste.disabled = false;
  }
};

var gatherAndSubmitData = function gatherAndSubmitData() {
  var name = document.getElementById('name').value.replace("'", "''");
  var contact = document.getElementById('contact').value.replace("'", "''");
  var sequenceName = document.getElementById('sequenceName').value.replace("'", "''");
  var genbank = document.getElementById('genbank').value.replace("'", "''");
  var sequenceFileString = document.getElementById('sequenceFileString').value.replace("'", "''");
  var sequence = document.getElementById('sequence').value.replace("'", "''");
  var about = document.getElementById('about').value.replace("'", "''");
  var taxon = document.getElementById('taxon').value.replace("'", "''");
  var species = document.getElementById('species').value.replace("'", "''");
  var journal = document.getElementById('journal').value.replace("'", "''");
  var article = document.getElementById('article').value.replace("'", "''");
  var articleLink = document.getElementById('articleLink').value.replace("'", "''");
  document.getElementById('nameForm').value = name;
  document.getElementById('contactForm').value = contact;
  document.getElementById('sequenceNameForm').value = sequenceName;
  document.getElementById('genbankForm').value = genbank;
  document.getElementById('aboutForm').value = about;
  document.getElementById('taxonForm').value = taxon;
  document.getElementById('speciesForm').value = species;
  document.getElementById('journalForm').value = journal;
  document.getElementById('articleForm').value = article;
  document.getElementById('articleLinkForm').value = articleLink;
  var sequenceForm = document.getElementById('sequenceForm');

  if (sequenceFileString !== "") {
    sequenceForm.value = sequenceFileString;
  } else {
    sequenceForm.value = sequence;
  }

  if (sequenceName && genbank && species && journal && article && articleLink && sequence) {
    var submit = document.getElementById("realSubmitButton");
    submit.click();
  } else {
    document.getElementById("EmptyFields").style.visibility = 'visible';
  }
};

var showResults = function showResults(rawJSON) {
  var makeTd = function makeTd() {
    var content = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : '';
    var href = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : null;
    var isLink = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : false;
    var tdNode = document.createElement('td');

    if (href) {
      var a = document.createElement('a');
      a.href = href;

      if (isLink) {
        a.target = '_blank';
        a.rel = 'noopener noreferrer nofollow';
      }

      a.innerHTML = content;
      tdNode.appendChild(a);
    } else {
      tdNode.innerHTML = content;
    }

    return tdNode;
  };

  var contentSeen = document.getElementById('content-seen');
  var noContentSeen = document.getElementById('no-content-seen');
  var data = JSON.parse(rawJSON);
  var table = document.getElementById('resultsTable'); // clearing table

  table.getElementsByTagName('tbody')[0].innerHTML = table.rows[0].innerHTML;

  if (data.length) {
    contentSeen.style.display = 'inline';
    noContentSeen.style.display = 'none';
    data.forEach(function (row) {
      var about = row.about,
        article = row.article,
        articleLink = row.articleLink,
        genbank = row.genbank,
        journal = row.journal,
        sequence = row.sequence,
        sequenceName = row.sequenceName,
        species = row.species,
        taxon = row.taxon;
      var tableRow = table.insertRow(table.rows.length);
      tableRow.className = 'tableRow';
      tableRow.id = genbank;
      tableRow.addEventListener('click', selectRow.bind(_this, tableRow), false);
      tableRow.appendChild(makeTd(genbank));
      tableRow.appendChild(makeTd(sequenceName));
      tableRow.appendChild(makeTd('FASTA', "/api/getSequences?sequenceGenbank=".concat(genbank)));
      tableRow.appendChild(makeTd('METADATA', "/api/getMetadata?sequenceGenbank=".concat(genbank)));
      tableRow.appendChild(makeTd(species));
      tableRow.appendChild(makeTd(taxon));
      tableRow.appendChild(makeTd(article, articleLink, true));
      tableRow.appendChild(makeTd(journal));

      if (about) {
        var div = document.createElement('div');
        div.className = 'my-tooltip';
        div.innerHTML = 'INFO';
        var span = document.createElement('span');
        span.className = 'my-tooltiptext';
        span.textContent = about;
        div.appendChild(span);
        var td = document.createElement('td');
        td.appendChild(div);
        tableRow.appendChild(td);
      }
    });
  } else {
    contentSeen.style.display = 'none';
    noContentSeen.style.display = 'inline';
    noContentSeen.innerHTML = '<span style="font-size: 24px;">Sorry, no results found!</span>';
  }
};

var getSequenceData = function getSequenceData(url) {
  new Promise(function (resolve, reject) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", decodeURIComponent(url));

    xhr.onload = function () {
      return resolve(xhr.responseText);
    };

    xhr.onerror = function () {
      return reject(xhr.statusText);
    };

    xhr.send();
  }).then(showResults);
};