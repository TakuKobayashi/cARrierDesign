const ytdl = require('ytdl-core');

const youtubeUrls = [
  // トヨタ工場製造組付け過程
  "https://www.youtube.com/watch?v=t0E66vaiXeg",
  "https://www.youtube.com/watch?v=cXMN8DuFhMQ",
  // 整備士、エンジニア
  "https://www.youtube.com/watch?v=-MA9RhXBWKE",
  "https://www.youtube.com/watch?v=SufHt7d1F1E",
  "https://www.youtube.com/watch?v=Nvw4i-L8ldg",
  "https://www.youtube.com/watch?v=b9aNGLmNWeU",
  // レース GT
  "https://www.youtube.com/watch?v=3R9lGbfkSTc",
  // レース ピットイン 整備士
  "https://www.youtube.com/watch?v=SV0g0-6Kfvc",
  "https://www.youtube.com/watch?v=fAvNOufdLgY",
  // 消防車
  "https://www.youtube.com/watch?v=h0jb83rxsw4",
  "https://www.youtube.com/watch?v=mlIb5J97ERs",
  "https://www.youtube.com/watch?v=PiRdD1K3zdE",
  // デザイナー関係
  "https://www.youtube.com/watch?v=RdR4BUZFUjw",
  "https://www.youtube.com/watch?v=jkEp7ELEgpA",
  // バス
  "https://www.youtube.com/watch?v=Jqq3vTPS1co",
  "https://www.youtube.com/watch?v=QXXeI8BCEm8",
  // 電車
  "https://www.youtube.com/watch?v=sX6yBz8qgFM",
  "https://www.youtube.com/watch?v=TQHjEH4bjJg",
  "https://www.youtube.com/watch?v=syLy13I092s",
  "https://www.youtube.com/watch?v=GqVeTOKdqeQ",
  // 電車整備
  "https://www.youtube.com/watch?v=ww0FL6SdEbg",
  "https://www.youtube.com/watch?v=0AW_2p8ZlUs",
  "https://www.youtube.com/watch?v=VUWeWXHY8mI",
  "https://www.youtube.com/watch?v=JyKw6Yl6D2I",
  // 飛行機関連
  "https://www.youtube.com/watch?v=bberp72rBVA",
  "https://www.youtube.com/watch?v=eiAEEkmREkQ",
  "https://www.youtube.com/watch?v=84psrM0ctnQ",
  "https://www.youtube.com/watch?v=wflOsmGROrI",
]

exports.handler = async (event, context) => {
  console.log(event);

  const infos = await Promise.all(youtubeUrls.map((youtubeUrl) => {
    return ytdl.getInfo(youtubeUrl)
  }));
  console.log(infos)
  return infos;
};
