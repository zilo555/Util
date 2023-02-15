﻿using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选择器测试 - 指令扩展
    /// </summary>
    public partial class SelectTagHelperTest {

        #region 辅助操作

        /// <summary>
        /// 添加选项
        /// </summary>
        private void AppendOptions( StringBuilder result ) {
            result.Append( "<ng-container *ngIf=\"!x_id.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_id.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_id.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_id.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
        }

        #endregion

        #region EnableExtend

        /// <summary>
        /// 测试启用扩展指令
        /// </summary>
        [Fact]
        public void TestEnableExtend_1() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\">" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令 - 不启用
        /// </summary>
        [Fact]
        public void TestEnableExtend_2() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            var result = new StringBuilder();
            result.Append( "<nz-select>" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region AutoLoad

        /// <summary>
        /// 测试初始化时是否自动加载数据
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
            var result = new StringBuilder();
            result.Append( "<nz-select [autoLoad]=\"false\">" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region QueryParam

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            _wrapper.SetContextAttribute( UiConst.QueryParam, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [(queryParam)]=\"a\">" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Sort

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select order=\"a\">" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestBindSort() {
            _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select [order]=\"a\">" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Url

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestUrl_1() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" url=\"a\" x-select-extend=\"\" " );
            result.Append( "[nzLoading]=\"x_id.loading\">" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\" " );
            result.Append( "[nzLoading]=\"x_id.loading\" [url]=\"a\">" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Data

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestData() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据源 - 多语言
        /// </summary>
        [Fact]
        public void TestData_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "<ng-container *ngIf=\"!x_id.isGroup\">" );
            result.Append( "<nz-option *ngFor=\"let item of x_id.options\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-container *ngIf=\"x_id.isGroup\">" );
            result.Append( "<nz-option-group *ngFor=\"let group of x_id.optionGroups\" [nzLabel]=\"group.text\">" );
            result.Append( "<nz-option *ngFor=\"let item of group.value\" [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "</nz-option>" );
            result.Append( "</nz-option-group>" );
            result.Append( "</ng-container>" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region DefaultOptionText

        /// <summary>
        /// 测试默认项文本
        /// </summary>
        [Fact]
        public void TestDefaultOptionText_1() {
            _wrapper.SetContextAttribute( UiConst.DefaultOptionText, " " );
            var result = new StringBuilder();
            result.Append( "<nz-select>" );
            result.Append( "<nz-option nzLabel=\" \"></nz-option>" );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认项文本 - 启用默认项文本
        /// </summary>
        [Fact]
        public void TestDefaultOptionText_2() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableDefaultOptionText = true } );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\">" );
            result.Append( "<nz-option [nzLabel]=\"'util.defaultOptionText'|i18n\"></nz-option>" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认项文本 - 启用默认项文本,覆盖
        /// </summary>
        [Fact]
        public void TestDefaultOptionText_3() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableDefaultOptionText = true } );
            _wrapper.SetContextAttribute( UiConst.DefaultOptionText, " " );
            var result = new StringBuilder();
            result.Append( "<nz-select #x_id=\"xSelectExtend\" x-select-extend=\"\">" );
            result.Append( "<nz-option nzLabel=\" \"></nz-option>" );
            AppendOptions( result );
            result.Append( "</nz-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}