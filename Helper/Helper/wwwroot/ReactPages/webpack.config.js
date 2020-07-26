const path = require("path");
const webPack = require("webpack");

module.exports = {
    entry: {
        HomeIndex: "./src/pages/Home/HomeIndexView.tsx",
        NewsIndex: "./src/pages/News/NewsIndexView.tsx",
    },
    //این خط ارور را به جای  این که در باندل نشان دهد  در کد اصلی نشان میدهد
    //شاید در پراداکشن پاک شود
    devtool: "#eval-source-map",

    // Enable sourcemaps for debugging webpack's output.
    //برای هر فایل تایپ اسکرپت یا فایل جی اس  میسازدد
    // devtool: "source-map",
    output: {
        filename: "[name].js",
        path: path.resolve(__dirname, "build"),
        publicPath: '/dist/'
    },

    resolve: {
        // Add '.ts' and '.tsx' and '.js' and '.jsx' as resolvable extensions.
        extensions: [".ts", ".tsx", ".js", ".jsx"],
    },
    module: {
        rules: [
            {
                test: /\.ts(x?)$/,
                exclude: /node_modules/,
                loader: "ts-loader",
            },
            // All output '.js' files will have any sourcemaps re-processed by 'source-map-loader'.FFّّّFّ
            {
                enforce: "pre",
                test: /\.js$/,
                loader: "source-map-loader",
            },
            {
                test: /\.(png|jpe?g|gif|svg)$/,
                use: {
                    loader: 'file-loader',
                    options: {
                        publicPath: 'build/',
                        name: '[path][name].[ext]'
                    }
                }
            }
        ],
    },

    // // // // When importing a module whose path matches one of the following, just
    // // // // assume a corresponding global variable exists and use that instead.
    // // // // This is important because it allows us to avoid bundling all of our
    // // // // dependencies, which allows browsers to cache those libraries between builds.
    // // // // externals: {
    // // // //   react: "React",
    // // // //   "react-dom": "ReactDOM",
    // // // // },
    plugins: [
        //این پلاگین در صد پیشرفت  بیلد را نشان میدهد
        new webPack.ProgressPlugin(),
    ],
};
