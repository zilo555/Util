﻿using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Paginations.Builders; 

/// <summary>
/// 分页标签生成器
/// </summary>
public class PaginationBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化分页标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public PaginationBuilder( Config config ) : base( config,"nz-pagination" ) {
        _config = config;
    }

    /// <summary>
    /// 配置总数
    /// </summary>
    public PaginationBuilder Total() {
        AttributeIfNotEmpty( "[nzTotal]", _config.GetValue( UiConst.Total ) );
        return this;
    }

    /// <summary>
    /// 配置当前页
    /// </summary>
    public PaginationBuilder PageIndex() {
        AttributeIfNotEmpty( "[nzPageIndex]", _config.GetValue( UiConst.PageIndex ) );
        AttributeIfNotEmpty( "[(nzPageIndex)]", _config.GetValue( AngularConst.BindonPageIndex ) );
        return this;
    }

    /// <summary>
    /// 配置每页显示行数
    /// </summary>
    public PaginationBuilder PageSize() {
        AttributeIfNotEmpty( "[nzPageSize]", _config.GetValue( UiConst.PageSize ) );
        AttributeIfNotEmpty( "[(nzPageSize)]", _config.GetValue( AngularConst.BindonPageSize ) );
        return this;
    }

    /// <summary>
    /// 配置显示改变分页大小按钮
    /// </summary>
    public PaginationBuilder ShowSizeChanger() {
        AttributeIfNotEmpty( "[nzShowSizeChanger]", _config.GetValue( UiConst.ShowSizeChanger ) );
        return this;
    }

    /// <summary>
    /// 配置显示快速跳转
    /// </summary>
    public PaginationBuilder ShowQuickJumper() {
        AttributeIfNotEmpty( "[nzShowQuickJumper]", _config.GetValue( UiConst.ShowQuickJumper ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public PaginationBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置尺寸
    /// </summary>
    public PaginationBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<PaginationSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置显示总行数和当前数据范围的模板
    /// </summary>
    public PaginationBuilder ShowTotal() {
        AttributeIfNotEmpty( "[nzShowTotal]", _config.GetValue( UiConst.ShowTotal ) );
        return this;
    }

    /// <summary>
    /// 配置简单分页
    /// </summary>
    public PaginationBuilder Simple() {
        AttributeIfNotEmpty( "[nzSimple]", _config.GetValue( UiConst.Simple ) );
        return this;
    }

    /// <summary>
    /// 配置响应式
    /// </summary>
    public PaginationBuilder Responsive() {
        AttributeIfNotEmpty( "[nzResponsive]", _config.GetValue( UiConst.Responsive ) );
        return this;
    }

    /// <summary>
    /// 配置每页行数选择列表
    /// </summary>
    public PaginationBuilder PageSizeOptions() {
        AttributeIfNotEmpty( "[nzPageSizeOptions]", _config.GetValue( UiConst.PageSizeOptions ) );
        return this;
    }

    /// <summary>
    /// 配置自定义页码结构
    /// </summary>
    public PaginationBuilder ItemRender() {
        AttributeIfNotEmpty( "[nzItemRender]", _config.GetValue( UiConst.ItemRender ) );
        return this;
    }

    /// <summary>
    /// 配置只有一页时是否隐藏分页器
    /// </summary>
    public PaginationBuilder HideOnSinglePage() {
        AttributeIfNotEmpty( "[nzHideOnSinglePage]", _config.GetValue( UiConst.HideOnSinglePage ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public PaginationBuilder Events() {
        AttributeIfNotEmpty( "(nzPageIndexChange)", _config.GetValue( UiConst.OnPageIndexChange ) );
        AttributeIfNotEmpty( "(nzPageSizeChange)", _config.GetValue( UiConst.OnPageSizeChange ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Total().PageIndex().PageSize().ShowSizeChanger().ShowQuickJumper().Disabled().Size()
            .ShowTotal().Simple().Responsive().PageSizeOptions().ItemRender().HideOnSinglePage()
            .Events();
    }
}