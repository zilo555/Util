﻿using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Radios.Configs;
using Util.Ui.NgZorro.Components.Selects.Helpers;

namespace Util.Ui.NgZorro.Components.Radios.Helpers; 

/// <summary>
/// 单选框组合服务
/// </summary>
public class RadioGroupService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 单选框组合共享配置
    /// </summary>
    private RadioGroupShareConfig _shareConfig;

    /// <summary>
    /// 初始化单选框组合服务
    /// </summary>
    /// <param name="config">配置</param>
    public RadioGroupService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 设置nz-radio-group已创建
    /// </summary>
    public void Created() {
        _shareConfig.RadioGroupCreated = true;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        LoadExpression();
        InitShareConfig();
        InitValidationService();
        InitFormShareService();
        InitFormItemShareService();
        EnableExtend();
        DisableAutoCreateRadioGroup();
        EnableAutoCreateRadio();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var loader = new SelectExpressionLoader();
        loader.Load( _config );
    }

    /// <summary>
    /// 初始化共享配置
    /// </summary>
    private void InitShareConfig() {
        _shareConfig = new RadioGroupShareConfig( GetRadioId() );
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 获取单选框标识
    /// </summary>
    private string GetRadioId() {
        return _config.GetValue( UiConst.Id );
    }

    /// <summary>
    /// 初始化验证服务
    /// </summary>
    private void InitValidationService() {
        var service = new ValidationService( _config );
        service.Init();
    }

    /// <summary>
    /// 初始化表单共享服务
    /// </summary>
    private void InitFormShareService() {
        var service = new FormShareService( _config );
        service.Init();
    }

    /// <summary>
    /// 初始化表单项共享服务
    /// </summary>
    private void InitFormItemShareService() {
        var service = new FormItemShareService( _config );
        service.Init();
        service.InitId();
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    private void EnableExtend() {
        if ( IsExtend() == false )
            return;
        _shareConfig.IsRadioGroupExtend = true;
        _shareConfig.IsRadioExtend = true;
    }

    /// <summary>
    /// 是否扩展
    /// </summary>
    private bool IsExtend() {
        if ( GetEnableExtend() == false )
            return false;
        if ( GetEnableExtend() == true )
            return true;
        if ( HasData() )
            return true;
        if ( HasUrl() )
            return true;
        return false;
    }

    /// <summary>
    /// 获取启用扩展属性
    /// </summary>
    private bool? GetEnableExtend() {
        return _config.GetValue<bool?>( UiConst.EnableExtend );
    }

    /// <summary>
    /// 是否设置数据源属性
    /// </summary>
    private bool HasData() {
        return _config.Contains( UiConst.Data );
    }

    /// <summary>
    /// 是否设置Api地址
    /// </summary>
    private bool HasUrl() {
        if ( _config.Contains( UiConst.Url ) )
            return true;
        return _config.Contains( AngularConst.BindUrl );
    }

    /// <summary>
    /// 禁用自动创建单选框组合
    /// </summary>
    private void DisableAutoCreateRadioGroup() {
        _shareConfig.IsAutoCreateRadioGroup = false;
    }

    /// <summary>
    /// 启用自动创建单选框
    /// </summary>
    private void EnableAutoCreateRadio() {
        if ( IsExtend() ) 
            _shareConfig.IsAutoCreateRadio = true;
    }
}