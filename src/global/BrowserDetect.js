/* BrowserDetect from http://www.quirksmode.org/js/detect.html */
import { browser } from '$app/environment'

const nav = browser ? navigator : {}
const win = browser ? window : {}

export const BrowserDetect = {
	init: function () {
		this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
		this.version = this.searchVersion(nav.userAgent)
			|| this.searchVersion(nav.appVersion)
			|| "an unknown version";
		this.OS = this.searchString(this.dataOS) || "an unknown OS";
	},
	searchString: function (data) {
		for (var i=0;i<data.length;i++)	{
			var dataString = data[i].string;
			var dataProp = data[i].prop;
			this.versionSearchString = data[i].versionSearch || data[i].identity;
			if (dataString) {
				if (dataString.indexOf(data[i].subString) != -1)
					return data[i].identity;
			}
			else if (dataProp)
				return data[i].identity;
		}
	},
	searchVersion: function (dataString) {
		var index = dataString.indexOf(this.versionSearchString);
		if (index == -1) return;
		return parseFloat(dataString.substring(index+this.versionSearchString.length+1));
	},
	dataBrowser: [
		{
			string: nav.userAgent,
			subString: "Chrome",
			identity: "Chrome"
		},
		{ 	string: nav.userAgent,
			subString: "OmniWeb",
			versionSearch: "OmniWeb/",
			identity: "OmniWeb"
		},
		{
			string: nav.vendor,
			subString: "Apple",
			identity: "Safari",
			versionSearch: "Version"
		},
		{
			prop: win.opera,
			identity: "Opera",
			versionSearch: "Version"
		},
		{
			string: nav.vendor,
			subString: "iCab",
			identity: "iCab"
		},
		{
			string: nav.vendor,
			subString: "KDE",
			identity: "Konqueror"
		},
		{
			string: nav.userAgent,
			subString: "Firefox",
			identity: "Firefox"
		},
		{
			string: nav.vendor,
			subString: "Camino",
			identity: "Camino"
		},
		{		// for newer Netscapes (6+)
			string: nav.userAgent,
			subString: "Netscape",
			identity: "Netscape"
		},
		{
			string: nav.userAgent,
			subString: "MSIE",
			identity: "Explorer",
			versionSearch: "MSIE"
		},
		{
			string: nav.userAgent,
			subString: "Gecko",
			identity: "Mozilla",
			versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
			string: nav.userAgent,
			subString: "Mozilla",
			identity: "Netscape",
			versionSearch: "Mozilla"
		}
	],
	dataOS : [
		{
			string: nav.platform,
			subString: "Win",
			identity: "Windows"
		},
		{
			string: nav.platform,
			subString: "Mac",
			identity: "Mac"
		},
		{
			   string: nav.userAgent,
			   subString: "iPhone",
			   identity: "iPhone/iPod"
	    },
		{
			string: nav.platform,
			subString: "Linux",
			identity: "Linux"
		}
	]

};

export const AutoWebSocketsUrl = () => {
	var pcol;
	var u = document.URL;

	/*
	 * We open the websocket encrypted if this page came on an
	 * https:// url itself, otherwise unencrypted
	 */

	if (u.substring(0, 5) == "https") {
		pcol = "wss://";
		u = u.substr(8);
	} else {
		pcol = "ws://";
		if (u.substring(0, 4) == "http")
			u = u.substr(7);
	}

	u = u.split('/');

	return pcol + u[0];
};