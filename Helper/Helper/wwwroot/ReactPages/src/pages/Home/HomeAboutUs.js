var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import React, { Fragment, useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import ReactHtmlParser from 'react-html-parser';
import agent from '../../app/api/agent';
import borderbig from '../../../assets/hj/img/borderbig green.png';
var HoemAboutUsView = function () {
    var _a = useState(undefined), aboutUs = _a[0], setAboutUs = _a[1];
    var _b = useState(false), loading = _b[0], setloading = _b[1];
    useEffect(function () {
        function fetchMyAPI() {
            return __awaiter(this, void 0, void 0, function () {
                var res, error_1;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            setloading(true);
                            _a.label = 1;
                        case 1:
                            _a.trys.push([1, 3, , 4]);
                            return [4 /*yield*/, agent.AboutUs.aboutUs()];
                        case 2:
                            res = _a.sent();
                            if (res.status == 1) {
                                setAboutUs(res.data.value);
                                setloading(false);
                            }
                            setloading(false);
                            return [3 /*break*/, 4];
                        case 3:
                            error_1 = _a.sent();
                            setloading(false);
                            return [3 /*break*/, 4];
                        case 4: return [2 /*return*/];
                    }
                });
            });
        }
        fetchMyAPI();
    }, []);
    if (loading) {
        return (React.createElement("div", { className: "container" },
            React.createElement("div", { className: "d-block text-center" },
                React.createElement("div", { className: "spinner-grow", role: "status" },
                    React.createElement("span", { className: "sr-only" }, "Loading...")))));
    }
    return (React.createElement(Fragment, null,
        React.createElement("div", { className: "container mx-auto p-0 m-0 mt-5" },
            React.createElement("div", { className: "row w-100 p-0 m-0 mx-auto" },
                React.createElement("div", { className: "col-md-10 col-8 text-right" },
                    React.createElement("h3", null,
                        React.createElement("b", null, "  \u062F\u0631\u0628\u0627\u0631\u0647 \u0645\u0627")))),
            React.createElement("div", { className: "row w-100 mx-auto" },
                React.createElement("img", { src: "/ReactPages/" + borderbig, className: "img-fluid mx-auto" })),
            React.createElement("div", { className: "row  p-2 m-0  mt-3" }, ReactHtmlParser(aboutUs || "")))));
};
ReactDOM.render(React.createElement(HoemAboutUsView, null), document.getElementById('root'));
//# sourceMappingURL=HomeAboutUs.js.map