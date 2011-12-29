<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  
  


  <head>
    <title>
      Default.aspx.cs in trunk/sky/AngleInGSky
     – GoogleSky
    </title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <link rel="search" href="/trac/GoogleSky/search" />
        <link rel="help" href="/trac/GoogleSky/wiki/TracGuide" />
        <link rel="alternate" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?format=txt" type="text/plain" title="Plain Text" /><link rel="alternate" href="/trac/GoogleSky/export/303/trunk/sky/AngleInGSky/Default.aspx.cs" type="text/x-csharp; charset=iso-8859-15" title="Original Format" />
        <link rel="start" href="/trac/GoogleSky/wiki" />
        <link rel="stylesheet" href="/trac/GoogleSky/chrome/common/css/trac.css" type="text/css" /><link rel="stylesheet" href="/trac/GoogleSky/chrome/common/css/code.css" type="text/css" /><link rel="stylesheet" href="/trac/GoogleSky/chrome/common/css/browser.css" type="text/css" />
        <link rel="prev" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?rev=96" title="Revision 96" />
        <link rel="shortcut icon" href="/trac/GoogleSky/chrome/common/trac.ico" type="image/x-icon" />
        <link rel="icon" href="/trac/GoogleSky/chrome/common/trac.ico" type="image/x-icon" />
      <link type="application/opensearchdescription+xml" rel="search" href="/trac/GoogleSky/search/opensearch" title="Search GoogleSky" />
    <script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/jquery.js"></script><script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/babel.js"></script><script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/trac.js"></script><script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/search.js"></script>
    <!--[if lt IE 7]>
    <script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/ie_pre7_hacks.js"></script>
    <![endif]-->
    <script type="text/javascript" src="/trac/GoogleSky/chrome/common/js/folding.js"></script><script type="text/javascript">
      jQuery(document).ready(function($) {
        $(".trac-toggledeleted").show().click(function() {
                  $(this).siblings().find(".trac-deleted").toggle();
                  return false;
        }).click();
        $("#jumploc input").hide();
        $("#jumploc select").change(function () {
          this.parentNode.parentNode.submit();
        });
          $('#preview table.code').enableCollapsibleColumns($('#preview table.code thead th.content'));
      });
    </script>
  </head>
  <body>
    <div id="banner">
      <div id="header">
        <a id="logo" href="https://www.stsci.edu/trac/GoogleSky"><img src="/trac/GoogleSky/chrome/site/GoogleSky.png" alt="" height="110" width="187" /></a>
      </div>
      <form id="search" action="/trac/GoogleSky/search" method="get">
        <div>
          <label for="proj-search">Search:</label>
          <input type="text" id="proj-search" name="q" size="18" value="" />
          <input type="submit" value="Search" />
        </div>
      </form>
      <div id="metanav" class="nav">
    <ul>
      <li class="first"><a href="/trac/GoogleSky/login">Login</a></li><li><a href="/trac/GoogleSky/wiki/TracGuide">Help/Guide</a></li><li><a href="/trac/GoogleSky/about">About Trac</a></li><li class="last"><a href="/trac/GoogleSky/prefs">Preferences</a></li>
    </ul>
  </div>
    </div>
    <div id="mainnav" class="nav">
    <ul>
      <li class="first"><a href="/trac/GoogleSky/wiki">Wiki</a></li><li><a href="/trac/GoogleSky/timeline">Timeline</a></li><li><a href="/trac/GoogleSky/roadmap">Roadmap</a></li><li class="active"><a href="/trac/GoogleSky/browser">Browse Source</a></li><li><a href="/trac/GoogleSky/report">View Tickets</a></li><li class="last"><a href="/trac/GoogleSky/search">Search</a></li>
    </ul>
  </div>
    <div id="main">
      <div id="ctxtnav" class="nav">
        <h2>Context Navigation</h2>
          <ul>
              <li class="first"><span>&larr; <a class="prev" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?rev=96" title="Revision 96">Previous Revision</a></span></li><li><span class="missing">Next Revision &rarr;</span></li><li><a href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?annotate=blame&amp;rev=166" title="Annotate each line with the last changed revision (this can be time consuming...)">Annotate</a></li><li class="last"><a href="/trac/GoogleSky/log/trunk/sky/AngleInGSky/Default.aspx.cs">Revision Log</a></li>
          </ul>
        <hr />
      </div>
    <div id="content" class="browser">
          <h1>
<a class="pathentry first" href="/trac/GoogleSky/browser?order=name" title="Go to repository root">source:</a>
<a class="pathentry" href="/trac/GoogleSky/browser/trunk?order=name" title="View trunk">trunk</a><span class="pathentry sep">/</span><a class="pathentry" href="/trac/GoogleSky/browser/trunk/sky?order=name" title="View sky">sky</a><span class="pathentry sep">/</span><a class="pathentry" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky?order=name" title="View AngleInGSky">AngleInGSky</a><span class="pathentry sep">/</span><a class="pathentry" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?order=name" title="View Default.aspx.cs">Default.aspx.cs</a>
<span class="pathentry sep">@</span>
  <a class="pathentry" href="/trac/GoogleSky/changeset/166" title="View changeset 166">166</a>
<br style="clear: both" />
</h1>
        <div id="jumprev">
          <form action="" method="get">
            <div>
              <label for="rev">
                View revision:</label>
              <input type="text" id="rev" name="rev" size="6" />
            </div>
          </form>
        </div>
        <div id="jumploc">
          <form action="" method="get">
            <div class="buttons">
              <label for="preselected">Visit:</label>
              <select id="preselected" name="preselected">
                <option selected="selected"></option>
                <optgroup label="branches">
                  <option value="/trac/GoogleSky/browser/trunk">trunk</option>
                </optgroup>
              </select>
              <input type="submit" value="Go!" title="Jump to the chosen preselected path" />
            </div>
          </form>
        </div>
      <table id="info" summary="Revision info">
        <tr>
          <th scope="col">Revision <a href="/trac/GoogleSky/changeset/166">166</a>,
            <span title="15187 bytes">14.8 KB</span>
            checked in by aconti, <a class="timeline" href="/trac/GoogleSky/timeline?from=2008-12-27T18%3A04%3A13-05%3A00&amp;precision=second" title="2008-12-27T18:04:13-05:00 in Timeline">2 years</a> ago
            (<a href="/trac/GoogleSky/changeset/166/trunk/sky/AngleInGSky/Default.aspx.cs">diff</a>)</th>
        </tr>
        <tr>
          <td class="message searchable">
              <p>
checking in new solution with BCG<br />
</p>
          </td>
        </tr>
      </table>
      <div id="preview" class="searchable">
        
  <table class="code"><thead><tr><th class="lineno" title="Line numbers">Line</th><th class="content"> </th></tr></thead><tbody><tr><th id="L1"><a href="#L1">1</a></th><td>/* Copyright 2007 Alberto Conti */

      </div>
      <div id="help"><strong>Note:</strong> See <a href="/trac/GoogleSky/wiki/TracBrowser">TracBrowser</a>
        for help on using the repository browser.</div>
      <div id="anydiff">
        <form action="/trac/GoogleSky/diff" method="get">
          <div class="buttons">
            <input type="hidden" name="new_path" value="/trunk/sky/AngleInGSky/Default.aspx.cs" />
            <input type="hidden" name="old_path" value="/trunk/sky/AngleInGSky/Default.aspx.cs" />
            <input type="hidden" name="new_rev" />
            <input type="hidden" name="old_rev" />
            <input type="submit" value="View changes..." title="Select paths and revs for Diff" />
          </div>
        </form>
      </div>
    </div>
    <div id="altlinks">
      <h3>Download in other formats:</h3>
      <ul>
        <li class="first">
          <a rel="nofollow" href="/trac/GoogleSky/browser/trunk/sky/AngleInGSky/Default.aspx.cs?format=txt">Plain Text</a>
        </li><li class="last">
          <a rel="nofollow" href="/trac/GoogleSky/export/303/trunk/sky/AngleInGSky/Default.aspx.cs">Original Format</a>
        </li>
      </ul>
    </div>
    </div>
    <div id="footer" lang="en" xml:lang="en"><hr />
      <a id="tracpowered" href="http://trac.edgewall.org/"><img src="/trac/GoogleSky/chrome/common/trac_logo_mini.png" height="30" width="107" alt="Trac Powered" /></a>
      <p class="left">Powered by <a href="/trac/GoogleSky/about"><strong>Trac 0.12</strong></a><br />
        By <a href="http://www.edgewall.org/">Edgewall Software</a>.</p>
      <p class="right">Visit the Trac open source project at<br /><a href="http://trac.edgewall.org/">http://trac.edgewall.org/</a></p>
    </div>
  </body>
</html>