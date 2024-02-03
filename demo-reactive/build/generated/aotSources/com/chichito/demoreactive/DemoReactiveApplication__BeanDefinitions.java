package com.chichito.demoreactive;

import org.springframework.aot.generate.Generated;
import org.springframework.beans.factory.config.BeanDefinition;
import org.springframework.beans.factory.support.RootBeanDefinition;
import org.springframework.context.annotation.ConfigurationClassUtils;

/**
 * Bean definitions for {@link DemoReactiveApplication}.
 */
@Generated
public class DemoReactiveApplication__BeanDefinitions {
  /**
   * Get the bean definition for 'demoReactiveApplication'.
   */
  public static BeanDefinition getDemoReactiveApplicationBeanDefinition() {
    RootBeanDefinition beanDefinition = new RootBeanDefinition(DemoReactiveApplication.class);
    beanDefinition.setTargetType(DemoReactiveApplication.class);
    ConfigurationClassUtils.initializeConfigurationClass(DemoReactiveApplication.class);
    beanDefinition.setInstanceSupplier(DemoReactiveApplication$$SpringCGLIB$$0::new);
    return beanDefinition;
  }
}
