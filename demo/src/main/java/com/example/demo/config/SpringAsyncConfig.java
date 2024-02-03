package com.example.demo.config;

import org.springframework.boot.SpringApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.scheduling.concurrent.ThreadPoolTaskExecutor;

import java.util.concurrent.Executor;

@Configuration
@EnableAsync
public class SpringAsyncConfig {  
    public static void main(String[] args) {
    // close the application context to shut down the custom ExecutorService
    SpringApplication.run(SpringAsyncConfig.class, args).close();
  }

  @Bean
  public Executor taskExecutor() {
    ThreadPoolTaskExecutor executor = new ThreadPoolTaskExecutor();
    executor.setCorePoolSize(700);
    executor.setMaxPoolSize(20000);
    executor.setQueueCapacity(50000);
    executor.initialize();
    return executor;
  }
}
