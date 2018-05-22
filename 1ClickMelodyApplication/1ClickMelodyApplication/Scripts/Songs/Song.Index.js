$(function () {
	$(".song").click(function () {
		$(".modal").css("display", "block");
		var trackName = $(this).attr("trackName");
		$("#lyricsHead").html("Lyrics for <b>" + trackName + "</b>");

		var trackId = $(this).attr("value");

		$.ajax({
			url: "/Songs/Lyrics",
			type: "POST",
			data: { trackId: trackId },
			success: function (res) {
				console.log(JSON.stringify(res));
				console.log("**success**");
			},
			error: function (eres) {
				console.log(eres);
				console.log("**error**");
			}
		});
	});

	$(".close").click(function () {
		$(".modal").css("display", "none");
	});
});
