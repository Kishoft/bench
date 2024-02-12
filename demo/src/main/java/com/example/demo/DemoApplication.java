package com.example.demo;

import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.concurrent.Executor;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.Bean;
import org.springframework.scheduling.concurrent.ThreadPoolTaskExecutor;
@SpringBootApplication
@EntityScan(basePackages = "com.example.demo.Models")
public class DemoApplication {

	public static void main(String[] args) {
		SpringApplication.run(DemoApplication.class, args);
	}

  @Bean
  public Executor taskExecutor() {
    ThreadPoolTaskExecutor executor = new ThreadPoolTaskExecutor();
    executor.setCorePoolSize(200);
    executor.setMaxPoolSize(200);
    executor.setQueueCapacity(500);
    executor.setThreadNamePrefix("eze-");
    executor.initialize();
    return executor;
  }
}
